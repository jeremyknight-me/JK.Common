using System.Text;

namespace JK.Common.Generators.SqlBulkInsert;

internal static class StringBuilderExtensions
{
    internal static void AppendCloseCurlyLine(this StringBuilder sb, int indentCount = 0)
    {
        if (indentCount > 0)
        {
            sb.AppendIndent(indentCount);
        }

        sb.AppendLine("}");
    }

    internal static void AppendEmptyLine(this StringBuilder sb) => sb.AppendLine("");

    internal static void AppendOpenCurlyLine(this StringBuilder sb, int indentCount = 0)
    {
        if (indentCount > 0)
        {
            sb.AppendIndent(indentCount);
        }

        sb.AppendLine("{");
    }

    internal static void AppendIndent(this StringBuilder sb, int count = 1)
        => sb.Append(new string(' ', count * 4));

    internal static void AppendIndentedLine(this StringBuilder sb, int indentCount, string text)
    {
        sb.AppendIndent(indentCount);
        sb.AppendLine(text);
    }

    internal static void AppendEmptyIndentedLine(this StringBuilder sb, int indentCount)
    {
        sb.AppendIndent(indentCount);
        sb.AppendLine("");
    }

    internal static void AppendNamespace(this StringBuilder sb, string ns)
    {
        if (!string.IsNullOrEmpty(ns))
        {
            sb.AppendLine($"namespace {ns};");
            sb.AppendEmptyLine();
        }
    }
}
