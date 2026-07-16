public record ParamInfo(string Name, string Description);
public record ExceptionInfo(string Type, string Description);
public record ProjectInfo(string CsprojPath, string ProjectDir, string AssemblyName, string? RootNamespace, string ProjectName);
public record NamespaceTypeEntry(string DisplayName, string FileName, string Summary);

public class TypeDoc
{
    public string Namespace { get; set; } = "";
    public string TypeName { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public List<ParamInfo> TypeParams { get; set; } = [];
    public List<string> TypeParamNames { get; set; } = [];
    public string GenericDisplayName
    {
        get
        {
            var baseName = Regexes.TrailingGeneric().Replace(TypeName, "");
            return TypeParamNames.Count > 0
                ? $"{baseName}<{string.Join(", ", TypeParamNames)}>"
                : baseName;
        }
    }
    public List<MemberDoc> Constructors { get; set; } = [];
    public List<MemberDoc> Methods { get; set; } = [];
    public List<MemberDoc> Properties { get; set; } = [];
    public List<MemberDoc> Events { get; set; } = [];
    public List<MemberDoc> Fields { get; set; } = [];
    public List<TypeDoc> NestedTypes { get; set; } = [];
}

public class MemberDoc
{
    public string DisplayName { get; set; } = "";
    public string Heading { get; set; } = "";
    public string InheritedSuffix { get; set; } = "";
    public string Signature { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Returns { get; set; } = "";
    public List<ParamInfo> Params { get; set; } = [];
    public List<ExceptionInfo> Exceptions { get; set; } = [];
    public string Example { get; set; } = "";
    public List<string> SeeAlso { get; set; } = [];
    public bool HasSummary => !string.IsNullOrWhiteSpace(Summary);
    public bool HasParams => Params.Count > 0;
    public bool HasReturns => !string.IsNullOrWhiteSpace(Returns);
    public bool HasRemarks => !string.IsNullOrWhiteSpace(Remarks);
    public bool HasExceptions => Exceptions.Count > 0;
    public bool HasExample => !string.IsNullOrWhiteSpace(Example);
}