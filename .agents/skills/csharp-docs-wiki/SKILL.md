---
name: csharp-docs-wiki
description: Generate a Markdown wiki in the docs folder from the compiler-generated C# XML documentation file.
user-invocable: true
argument-hint: "[optional path to XML documentation file]"
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

After building the project, the XML documentation file will appear under `bin/` (for example: `bin/Debug/net8.0/MyProject.xml`).

## When to use this skill

Use this skill when you want to:

- Convert XML doc comments into Markdown documentation.
- Regenerate documentation after updating comments.
- Produce a navigable wiki under the `docs` folder.
- Create documentation organized by namespace and type.

Invoke it with:

- `/csharp-docs-wiki` — auto-discover all projects, build, and generate
- `/csharp-docs-wiki bin/Debug/net8.0/MyProject.xml` — process a single XML file

## How it works

This skill uses a .NET file-based app (`XmlDocsToWiki.cs`) that runs with `dotnet run`. It requires .NET 10 SDK or later.

### Single file mode

When given an XML path, the tool processes that one file:

```
dotnet run --file .agents/skills/csharp-docs-wiki/XmlDocsToWiki.cs -- bin/Debug/net10.0/JK.Common.xml
```

### Auto-discovery mode

When invoked without arguments, the tool:

1. Finds the repo root by looking for `.sln` or `.slnx` files
2. Discovers all `.csproj` files under `src/` (excluding test projects)
3. Filters to projects with `GenerateDocumentationFile` enabled
4. Builds each project for `net10.0`
5. Processes the resulting XML documentation files
6. Generates the complete wiki under `docs/`

```
dotnet run --file .agents/skills/csharp-docs-wiki/XmlDocsToWiki.cs
```

## Output structure

Documentation is organized by project root namespace, with child namespaces as subfolders. Each type gets its own Markdown file. Each folder gets a `README.md` index.

```
docs/
├── README.md
├── JK.Common/
│   ├── README.md
│   ├── Constants.md
│   ├── Data/
│   │   ├── README.md
│   │   ├── OperationBase.md
│   │   └── Extensions/
│   │       ├── README.md
│   │       └── DataRecordExtensions.md
│   ├── Extensions/
│   │   └── StringExtensions.md
│   └── Patterns/
│       └── ServiceLocator/
│           ├── README.md
│           ├── IServiceLocator.md
│           └── DefaultServiceLocator.md
├── JK.Common.EntityFrameworkCore/
│   ├── README.md
│   └── Extensions/
│       └── ModelBuilderExtensions.md
```

### Namespace simplification

The tool uses the project name as the top-level folder (or `RootNamespace` if set in the `.csproj`). Child namespaces only include additional segments:

| Full Namespace | Output Folder |
|---|---|
| `JK.Common` | `JK.Common/` |
| `JK.Common.Data` | `JK.Common/Data/` |
| `JK.Common.Data.Extensions` | `JK.Common/Data/Extensions/` |
| `JK.Common.Patterns.ServiceLocator` | `JK.Common/Patterns/ServiceLocator/` |

## Features

- **Cross-platform**: Runs on any OS with .NET SDK (no PowerShell dependency)
- **Template-based output**: Customize documentation by editing templates in `templates/`
- **Nested types**: Included in parent type's file
- **Inherited members**: Marked with "(Inherited)" indicator
- **XML tag support**: Converts `<see>`, `<code>`, `<example>`, `<list>`, etc. to Markdown
- **Cross-references**: `<see cref>` converted to bold type names

## Templates

Templates use a simple syntax:

| Feature | Syntax | Example |
|---|---|---|
| Variable | `{Variable}` | `{TypeName}` |
| Loop | `{#each Items}...{/each}` | `{#each Methods}{Body}{/each}` |
| Conditional | `{#if Condition}...{/if}` | `{#if HasReturns}{Returns}{/if}` |
| Literal `{` | `{{` | `{{not a variable}}` |

Template files are in `templates/`:

- `type.md` — page template for each type
- `member.md` — template for methods, properties, events, and fields
- `index.md` — unused (README files are generated inline)

## Example user prompts

- "Generate C# documentation from the XML file."
- "Update the docs folder using the XML documentation."
- "Create a Markdown wiki from my XML doc comments."
- "/csharp-docs-wiki bin/Debug/net10.0/MyProject.xml"
