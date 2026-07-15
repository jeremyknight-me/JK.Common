---
name: csharp-docs-wiki
description: Generate a Markdown wiki in the docs folder from the compiler-generated C# XML documentation file.
user-invocable: true
argument-hint: "[optional path to XML documentation file]"
metadata:
  author: "Jeremy Knight"
  version: "0.1"
---

# C# XML Documentation → Markdown Wiki

## Overview

This skill converts the compiler-generated C# XML documentation file into a structured Markdown wiki inside the `docs` folder. It organizes output by namespace and type, producing readable documentation pages for classes, methods, parameters, return values, remarks, and other XML doc elements.

To use this skill, ensure your `.csproj` enables XML documentation generation:

```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

After building the project, the XML documentation file will appear under `bin/` (for example: `bin/Debug/net10.0/MyProject.xml`).

## When to use this skill

Use this skill when you want to:

- Convert XML doc comments into Markdown documentation.
- Regenerate documentation after updating comments.
- Produce a navigable wiki under the `docs` folder.
- Create documentation organized by namespace and type.

Invoke it with:

- `/csharp-docs-wiki` — agent discovers projects, builds, and generates docs from XML
- `/csharp-docs-wiki bin/Debug/net10.0/MyProject.xml` — process a single XML file

## How it works

This skill uses a .NET file-based app (`XmlDocsToWiki.cs`) that converts XML documentation files into Markdown. It requires .NET 10 SDK or later. The agent is responsible for building projects and passing the resulting XML files to the tool.

### Agent workflow

When invoked, the agent should:

1. Find the repo root by looking for `.sln` or `.slnx` files
2. Discover all `.csproj` files under `src/` (excluding test projects)
3. Filter to projects with `GenerateDocumentationFile` enabled
4. Build each project: `dotnet build <csproj> -f net10.0`
5. Collect the resulting XML documentation files from `bin/Debug/net10.0/`
6. Pass all XML files to the tool:

### Usage

```bash
dotnet run --file .agents/skills/csharp-docs-wiki/XmlDocsToWiki.cs -- --help
dotnet run --file .agents/skills/csharp-docs-wiki/XmlDocsToWiki.cs -- --files <xml-file> [xml-file ...] [--output <path>]
```

- `--files` — One or more paths to XML documentation files (required)
- `--output` — Output directory (default: `./docs`)
- `--help` — Show usage and option details
- Unknown arguments are treated as errors (strict parsing)

### Example

```bash
# Agent builds projects that emit XML documentation, then runs the tool
dotnet build path/to/MyProject.csproj -f net10.0
dotnet build path/to/MyProject.Data.csproj -f net10.0

dotnet run --file .agents/skills/csharp-docs-wiki/XmlDocsToWiki.cs -- \
  --files \
    path/to/MyProject/bin/Debug/net10.0/MyProject.xml \
    path/to/MyProject.Data/bin/Debug/net10.0/MyProject.Data.xml \
  --output docs
```

## Output structure

Documentation is organized by project root namespace, with child namespaces as subfolders. Each type gets its own Markdown file. Each folder gets a `README.md` index.

```
docs/
├── README.md
├── MyProject/
│   ├── README.md
│   ├── MyClass.md
│   └── Models/
│       ├── README.md
│       └── Order.md
├── MyProject.Data/
│   ├── README.md
│   └── Extensions/
│       └── RecordExtensions.md
└── MyProject.Core/
    └── README.md
```

### Namespace simplification

The tool uses the project name as the top-level folder (or `RootNamespace` if set in the `.csproj`). Child namespaces only include additional segments:

| Full Namespace | Output Folder |
|---|---|
| `MyProject` | `MyProject/` |
| `MyProject.Models` | `MyProject/Models/` |
| `MyProject.Data.Extensions` | `MyProject.Data/Extensions/` |
| `MyProject.Core.Services` | `MyProject.Core/Services/` |

## Features

- **Cross-platform**: Runs on any OS with .NET SDK (no PowerShell dependency)
- **Template-based output**: Customize documentation by editing Liquid templates in `templates/` (powered by [Fluid](https://github.com/sebastienros/fluid))
- **Nested types**: Included in parent type's file
- **Inherited members**: Marked with "(Inherited)" indicator
- **XML tag support**: Converts `<see>`, `<code>`, `<example>`, `<list>`, etc. to Markdown
- **Cross-references**: `<see cref>` converted to bold type names

## Templates

Templates use [Liquid](https://shopify.github.io/liquid/) syntax via the [Fluid](https://github.com/sebastienros/fluid) template engine:

| Feature | Syntax | Example |
|---|---|---|
| Variable | `{{ Variable }}` | `{{ TypeName }}` |
| Loop | `{% for item in Items %}...{% endfor %}` | `{% for m in Methods %}{{ m.Body }}{% endfor %}` |
| Conditional | `{% if Condition %}...{% endif %}` | `{% if HasReturns %}**Returns:** {{ Returns }}{% endif %}` |
| Nested access | `{{ item.Property }}` | `{{ param.Name }}` |

Template files are in `templates/`:

- `type.md` — page template for each type
- `member.md` — template for methods, properties, events, and fields

## Example user prompts

- "Generate C# documentation from the XML file."
- "Update the docs folder using the XML documentation."
- "Create a Markdown wiki from my XML doc comments."
- "/csharp-docs-wiki bin/Debug/net10.0/MyProject.xml" — agent passes to `--files`
