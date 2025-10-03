using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification that determines if a <see cref="DateTime"/> value is valid for a SQL 'datetime' column (year >= 1753).
/// </summary>
public sealed class SqlDateSpecification : Specification<DateTime>
{
    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> is valid for a SQL 'datetime' column (year >= 1753).
    /// </summary>
    /// <param name="candidate">The date to evaluate.</param>
    /// <returns><c>true</c> if the date is valid for SQL; otherwise, <c>false</c>.</returns>
    public override bool IsSatisfiedBy(in DateTime candidate) => candidate.Year >= 1753;
}
