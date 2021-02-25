using System.Collections.Generic;
using JK.Common.TypeHelpers;

namespace JK.Common.Linq.Expressions
{
    public static class ExpressionFilterTypeHelper
    {
        public static string GetTitle(ExpressionFilterType filterType) => new EnumHelper().GetDisplayName(filterType);
    }
}
