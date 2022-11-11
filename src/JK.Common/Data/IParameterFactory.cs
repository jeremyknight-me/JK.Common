using System;
using System.Data;

namespace JK.Common.Data;

/// <summary>
/// ParameterFactory inferface which exposes multiple ways to make db parameters.
/// </summary>
[Obsolete("Moving this functionality to extension methods on the parameter collection classes")]
public interface IParameterFactory
{
    /// <summary>
    /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
    /// </summary>
    /// <typeparam name="T">Generic type to use.</typeparam>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">Value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    IDbDataParameter Make<T>(string name, T value, ParameterDirection direction = ParameterDirection.Input);

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
    /// </summary>
    /// <typeparam name="T">Generic type to use.</typeparam>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">Value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    IDbDataParameter Make<T>(string name, T? value, ParameterDirection direction = ParameterDirection.Input) where T : struct;

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a String DbParameter.
    /// </summary>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">String value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    IDbDataParameter Make(string name, string value, ParameterDirection direction = ParameterDirection.Input);
}
