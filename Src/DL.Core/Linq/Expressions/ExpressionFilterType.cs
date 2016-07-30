using DL.Core.Enums;

namespace DL.Core.Linq.Expressions
{
    public enum ExpressionFilterType
    {
        Equals = 0,
        [EnumLabel("Between (Inclusive)")]
        BetweenInclusive = 1,
        [EnumLabel("Between (Exclusive)")]
        BetweenExclusive = 2,
        [EnumLabel("Less Than")]
        LessThan = 3,
        [EnumLabel("Less Than or Equal")]
        LessThanOrEqual = 4,
        [EnumLabel("Greater Than")]
        GreaterThan = 5,
        [EnumLabel("Greater Than or Equal")]
        GreaterThanOrEqual = 6,
        Contains = 7,
        [EnumLabel("Starts With")]
        StartsWith = 8,
        [EnumLabel("Ends With")]
        EndsWith = 9
    }
}
