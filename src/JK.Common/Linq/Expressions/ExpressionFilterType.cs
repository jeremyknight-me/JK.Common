using System.ComponentModel.DataAnnotations;

namespace JK.Common.Linq.Expressions
{
    public enum ExpressionFilterType
    {
        Equals = 0,

        [Display(Name = "Between (Inclusive)")]
        BetweenInclusive = 1,

        [Display(Name = "Between (Exclusive)")]
        BetweenExclusive = 2,

        [Display(Name = "Less Than")]
        LessThan = 3,

        [Display(Name = "Less Than or Equal")]
        LessThanOrEqual = 4,

        [Display(Name = "Greater Than")]
        GreaterThan = 5,

        [Display(Name = "Greater Than or Equal")]
        GreaterThanOrEqual = 6,

        Contains = 7,

        [Display(Name = "Starts With")]
        StartsWith = 8,

        [Display(Name = "Ends With")]
        EndsWith = 9
    }
}
