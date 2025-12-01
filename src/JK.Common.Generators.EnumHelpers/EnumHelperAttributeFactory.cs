namespace JK.Common.Generators.EnumHelpers;

internal static class EnumHelperAttributeFactory
{
    internal const string SourceCode =
        """
        namespace JK.Common.Generators.EnumHelpers;

        [System.AttributeUsage(System.AttributeTargets.Enum)]
        internal class EnumHelpersAttribute : System.Attribute
        {
            public EnumHelpersAttribute() {}
        }
        """;
}
