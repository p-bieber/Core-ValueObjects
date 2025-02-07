using Bieber.Core.Helpers;
using Bieber.Core.ValueObjects.Helper;
using FluentValidation;
using FluentValidation.Results;

namespace Bieber.Core.ValueObjects.Base;

/// <summary>
/// Represents a validated value object with a single value.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public abstract class ValidatedValueObject<T>
    : ValueObject<T>
{
    /// <summary>
    /// List of validators for the value.
    /// </summary>
    protected readonly List<IValidator<T>> Validators = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatedValueObject{T}"/> class.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    protected ValidatedValueObject(T value, bool throwExceptionOnFailure = true)
        : base(value)
    {
        AddRegisteredValidators();
        _ = Validate(value, throwExceptionOnFailure);
    }

    private void AddRegisteredValidators()
    {
        Validators.AddRange(RegisterValidators());
    }

    /// <summary>
    /// Validates the provided values using the respective validators.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    /// <returns>A ValidationResult indicating the outcome of the validation.</returns>
    protected ValidationResult Validate(T value, bool throwExceptionOnFailure = true)
    {
        ObjectHelper.EnsureNotNull(value, nameof(value));
        return ValidationHelper.Validate(Validators, value, throwExceptionOnFailure);
    }

    /// <summary>
    /// Registers the validators for the value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T>> RegisterValidators();
}

/// <summary>
/// Represents a validated value object with two values.
/// </summary>
/// <typeparam name="T1">The type of the first value.</typeparam>
/// <typeparam name="T2">The type of the second value.</typeparam>
public abstract class ValidatedValueObject<T1, T2>
    : ValueObject<T1, T2>
{
    /// <summary>
    /// List of validators for the first value.
    /// </summary>
    protected readonly List<IValidator<T1>> Validators1 = [];

    /// <summary>
    /// List of validators for the second value.
    /// </summary>
    protected readonly List<IValidator<T2>> Validators2 = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatedValueObject{T1, T2}"/> class.
    /// </summary>
    /// <param name="value1">The first value to be validated.</param>
    /// <param name="value2">The second value to be validated.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    protected ValidatedValueObject(T1 value1, T2 value2, bool throwExceptionOnFailure = true)
        : base(value1, value2)
    {
        AddRegisteredValidators();
        _ = Validate(value1, value2, throwExceptionOnFailure);
    }

    private void AddRegisteredValidators()
    {
        Validators1.AddRange(RegisterValidators1());
        Validators2.AddRange(RegisterValidators2());
    }

    /// <summary>
    /// Validates the provided values using the respective validators.
    /// </summary>
    /// <param name="value1">The first value to validate.</param>
    /// <param name="value2">The second value to validate.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    /// <returns>A ValidationResult indicating the outcome of the validation.</returns>
    protected ValidationResult Validate(T1 value1, T2 value2, bool throwExceptionOnFailure = true)
    {
        ObjectHelper.EnsureNotNull(value1, nameof(value1));
        ObjectHelper.EnsureNotNull(value2, nameof(value2));
        return new ValidationResult([
            ValidationHelper.Validate(Validators1, value1, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators2, value2, throwExceptionOnFailure)
        ]);
    }

    /// <summary>
    /// Registers the validators for the first value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T1>> RegisterValidators1();

    /// <summary>
    /// Registers the validators for the second value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T2>> RegisterValidators2();

}

/// <summary>
/// Represents a validated value object with three values.
/// </summary>
/// <typeparam name="T1">The type of the first value.</typeparam>
/// <typeparam name="T2">The type of the second value.</typeparam>
/// <typeparam name="T3">The type of the third value.</typeparam>
public abstract class ValidatedValueObject<T1, T2, T3>
    : ValueObject<T1, T2, T3>
{
    /// <summary>
    /// List of validators for the first value.
    /// </summary>
    protected readonly List<IValidator<T1>> Validators1 = [];

    /// <summary>
    /// List of validators for the second value.
    /// </summary>
    protected readonly List<IValidator<T2>> Validators2 = [];

    /// <summary>
    /// List of validators for the third value.
    /// </summary>
    protected readonly List<IValidator<T3>> Validators3 = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatedValueObject{T1, T2, T3}"/> class.
    /// </summary>
    /// <param name="value1">The first value to be validated.</param>
    /// <param name="value2">The second value to be validated.</param>
    /// <param name="value3">The third value to be validated.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    protected ValidatedValueObject(T1 value1, T2 value2, T3 value3, bool throwExceptionOnFailure = true)
        : base(value1, value2, value3)
    {
        AddRegisteredValidators();
        _ = Validate(value1, value2, value3, throwExceptionOnFailure);
    }

    private void AddRegisteredValidators()
    {
        Validators1.AddRange(RegisterValidators1());
        Validators2.AddRange(RegisterValidators2());
        Validators3.AddRange(RegisterValidators3());
    }

    /// <summary>
    /// Validates the provided values using the respective validators.
    /// </summary>
    /// <param name="value1">The first value to validate.</param>
    /// <param name="value2">The second value to validate.</param>
    /// <param name="value3">The third value to validate.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    /// <returns>A ValidationResult indicating the outcome of the validation.</returns>
    protected ValidationResult Validate(T1 value1, T2 value2, T3 value3, bool throwExceptionOnFailure = true)
    {
        ObjectHelper.EnsureNotNull(value1, nameof(value1));
        ObjectHelper.EnsureNotNull(value2, nameof(value2));
        ObjectHelper.EnsureNotNull(value3, nameof(value3));

        return new ValidationResult([
           ValidationHelper.Validate(Validators1, value1, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators2, value2, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators3, value3, throwExceptionOnFailure)
       ]);
    }

    /// <summary>
    /// Registers the validators for the first value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T1>> RegisterValidators1();

    /// <summary>
    /// Registers the validators for the second value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T2>> RegisterValidators2();

    /// <summary>
    /// Registers the validators for the third value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T3>> RegisterValidators3();

}

/// <summary>
/// Represents a validated value object with four values.
/// </summary>
/// <typeparam name="T1">The type of the first value.</typeparam>
/// <typeparam name="T2">The type of the second value.</typeparam>
/// <typeparam name="T3">The type of the third value.</typeparam>
/// <typeparam name="T4">The type of the fourth value.</typeparam>
public abstract class ValidatedValueObject<T1, T2, T3, T4>
    : ValueObject<T1, T2, T3, T4>
{
    /// <summary>
    /// List of validators for the first value.
    /// </summary>
    protected readonly List<IValidator<T1>> Validators1 = [];

    /// <summary>
    /// List of validators for the second value.
    /// </summary>
    protected readonly List<IValidator<T2>> Validators2 = [];

    /// <summary>
    /// List of validators for the third value.
    /// </summary>
    protected readonly List<IValidator<T3>> Validators3 = [];

    /// <summary>
    /// List of validators for the fourth value.
    /// </summary>
    protected readonly List<IValidator<T4>> Validators4 = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatedValueObject{T1, T2, T3, T4}"/> class.
    /// </summary>
    /// <param name="value1">The first value to be validated.</param>
    /// <param name="value2">The second value to be validated.</param>
    /// <param name="value3">The third value to be validated.</param>
    /// <param name="value4">The fourth value to be validated.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    protected ValidatedValueObject(T1 value1, T2 value2, T3 value3, T4 value4, bool throwExceptionOnFailure = true)
        : base(value1, value2, value3, value4)
    {
        AddRegisteredValidators();
        _ = Validate(value1, value2, value3, value4, throwExceptionOnFailure);
    }

    private void AddRegisteredValidators()
    {
        Validators1.AddRange(RegisterValidators1());
        Validators2.AddRange(RegisterValidators2());
        Validators3.AddRange(RegisterValidators3());
        Validators4.AddRange(RegisterValidators4());
    }

    /// <summary>
    /// Validates the provided values using the respective validators.
    /// </summary>
    /// <param name="value1">The first value to validate.</param>
    /// <param name="value2">The second value to validate.</param>
    /// <param name="value3">The third value to validate.</param>
    /// <param name="value4">The fourth value to validate.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    /// <returns>A ValidationResult indicating the outcome of the validation.</returns>
    protected ValidationResult Validate(T1 value1, T2 value2, T3 value3, T4 value4, bool throwExceptionOnFailure = true)
    {
        ObjectHelper.EnsureNotNull(value1, nameof(value1));
        ObjectHelper.EnsureNotNull(value2, nameof(value2));
        ObjectHelper.EnsureNotNull(value3, nameof(value3));
        ObjectHelper.EnsureNotNull(value4, nameof(value4));

        return new ValidationResult([
            ValidationHelper.Validate(Validators1, value1, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators2, value2, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators3, value3, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators4, value4, throwExceptionOnFailure)
        ]);
    }

    /// <summary>
    /// Registers the validators for the first value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T1>> RegisterValidators1();

    /// <summary>
    /// Registers the validators for the second value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T2>> RegisterValidators2();

    /// <summary>
    /// Registers the validators for the third value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T3>> RegisterValidators3();

    /// <summary>
    /// Registers the validators for the fourth value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T4>> RegisterValidators4();

}

/// <summary>
/// Represents a validated value object with five values.
/// </summary>
/// <typeparam name="T1">The type of the first value.</typeparam>
/// <typeparam name="T2">The type of the second value.</typeparam>
/// <typeparam name="T3">The type of the third value.</typeparam>
/// <typeparam name="T4">The type of the fourth value.</typeparam>
/// <typeparam name="T5">The type of the fifth value.</typeparam>
public abstract class ValidatedValueObject<T1, T2, T3, T4, T5>
    : ValueObject<T1, T2, T3, T4, T5>
{
    /// <summary>
    /// List of validators for the first value.
    /// </summary>
    protected readonly List<IValidator<T1>> Validators1 = [];

    /// <summary>
    /// List of validators for the second value.
    /// </summary>
    protected readonly List<IValidator<T2>> Validators2 = [];

    /// <summary>
    /// List of validators for the third value.
    /// </summary>
    protected readonly List<IValidator<T3>> Validators3 = [];

    /// <summary>
    /// List of validators for the fourth value.
    /// </summary>
    protected readonly List<IValidator<T4>> Validators4 = [];

    /// <summary>
    /// List of validators for the fifth value.
    /// </summary>
    protected readonly List<IValidator<T5>> Validators5 = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatedValueObject{T1, T2, T3, T4, T5}"/> class.
    /// </summary>
    /// <param name="value1">The first value to be validated.</param>
    /// <param name="value2">The second value to be validated.</param>
    /// <param name="value3">The third value to be validated.</param>
    /// <param name="value4">The fourth value to be validated.</param>
    /// <param name="value5">The fifth value to be validated.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    protected ValidatedValueObject(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, bool throwExceptionOnFailure = true)
        : base(value1, value2, value3, value4, value5)
    {
        AddRegisteredValidators();
        _ = Validate(value1, value2, value3, value4, value5, throwExceptionOnFailure);
    }

    private void AddRegisteredValidators()
    {
        Validators1.AddRange(RegisterValidators1());
        Validators2.AddRange(RegisterValidators2());
        Validators3.AddRange(RegisterValidators3());
        Validators4.AddRange(RegisterValidators4());
        Validators5.AddRange(RegisterValidators5());
    }

    /// <summary>
    /// Validates the provided values using the respective validators.
    /// </summary>
    /// <param name="value1">The first value to validate.</param>
    /// <param name="value2">The second value to validate.</param>
    /// <param name="value3">The third value to validate.</param>
    /// <param name="value4">The fourth value to validate.</param>
    /// <param name="value5">The fifth value to validate.</param>
    /// <param name="throwExceptionOnFailure">Indicates whether to throw an exception if validation fails. Default is true.</param>
    /// <returns>A ValidationResult indicating the outcome of the validation.</returns>
    protected ValidationResult Validate(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, bool throwExceptionOnFailure = true)
    {
        ObjectHelper.EnsureNotNull(value1, nameof(value1));
        ObjectHelper.EnsureNotNull(value2, nameof(value2));
        ObjectHelper.EnsureNotNull(value3, nameof(value3));
        ObjectHelper.EnsureNotNull(value4, nameof(value4));
        ObjectHelper.EnsureNotNull(value5, nameof(value5));

        return new ValidationResult([
            ValidationHelper.Validate(Validators1, value1, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators2, value2, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators3, value3, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators4, value4, throwExceptionOnFailure),
            ValidationHelper.Validate(Validators5, value5, throwExceptionOnFailure)
         ]);
    }

    /// <summary>
    /// Registers the validators for the first value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T1>> RegisterValidators1();

    /// <summary>
    /// Registers the validators for the second value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T2>> RegisterValidators2();

    /// <summary>
    /// Registers the validators for the third value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T3>> RegisterValidators3();

    /// <summary>
    /// Registers the validators for the fourth value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T4>> RegisterValidators4();

    /// <summary>
    /// Registers the validators for the fifth value.
    /// </summary>
    protected abstract IEnumerable<IValidator<T5>> RegisterValidators5();
}
