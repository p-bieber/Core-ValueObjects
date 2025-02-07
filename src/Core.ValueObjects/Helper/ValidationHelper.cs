using FluentValidation;
using FluentValidation.Results;

namespace Bieber.Core.ValueObjects.Helper;

/// <summary>
/// Provides helper methods for validating objects using FluentValidation.
/// </summary>
public static class ValidationHelper
{
    /// <summary>
    /// Validates a value using a collection of validators.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="validators">The validators to use for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="throwExceptionOnFailure">Whether to throw an exception if validation fails.</param>
    /// <returns>A tuple containing a boolean indicating if validation succeeded and the validation results.</returns>
    /// <exception cref="ValidationException">Thrown if validation fails and throwExceptionOnFailure is true.</exception>
    public static ValidationResult Validate<T>(IEnumerable<IValidator<T>> validators, T value, bool throwExceptionOnFailure = true)
    {
        ValidationResult validationResult = new(validators.Select(v => v.Validate(value)).ToList());

        if (!validationResult.IsValid && throwExceptionOnFailure)
        {
            throw new ValidationException("Validation failed!", validationResult.Errors);
        }
        return validationResult;
    }

}
