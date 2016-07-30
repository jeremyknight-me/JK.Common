using System.Collections.Generic;

namespace DL.Core.Expressions
{
    public class ExpressionFilterTypeHelper
    {
        private readonly Dictionary<ExpressionFilterType, string> titleStrategies = new Dictionary<ExpressionFilterType, string>();  

        public ExpressionFilterTypeHelper()
        {
            this.DefineTitleStrategies();
        }

        public string GetTitle(ExpressionFilterType filterType)
        {
            return this.titleStrategies[filterType];
        }

        private void DefineTitleStrategies()
        {
            this.titleStrategies.Add(ExpressionFilterType.BetweenExclusive, "Between (Exclusive)");
            this.titleStrategies.Add(ExpressionFilterType.BetweenInclusive, "Between (Inclusive)");
            this.titleStrategies.Add(ExpressionFilterType.Contains, "Contains");
            this.titleStrategies.Add(ExpressionFilterType.EndsWith, "End With");
            this.titleStrategies.Add(ExpressionFilterType.Equals, "Equals");
            this.titleStrategies.Add(ExpressionFilterType.GreaterThan, "Greater Than");
            this.titleStrategies.Add(ExpressionFilterType.GreaterThanOrEqual, "Greater Than or Equal");
            this.titleStrategies.Add(ExpressionFilterType.LessThan, "Less Than");
            this.titleStrategies.Add(ExpressionFilterType.LessThanOrEqual, "Less Than or Equal");
            this.titleStrategies.Add(ExpressionFilterType.StartsWith, "Starts With");
        }
    }
}
