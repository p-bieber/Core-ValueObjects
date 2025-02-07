using Bieber.Core.Helpers;

namespace Bieber.Core.ValueObjects.Base;

/// <summary>
/// Represents a base class for value objects with a specific type.
/// </summary>
public abstract class ValueObject<T> : ValueObject
{
    /// <summary>
    /// Gets the value of the value object.
    /// </summary>
    public T Value { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObject{T}"/> class.
    /// </summary>
    /// <param name="value">The value of the value object.</param>
    /// <exception cref="ArgumentNullException">Thrown if the value is null.</exception>
    protected ValueObject(T value)
    {
        ObjectHelper.EnsureNotNull(value, nameof(value));
        Value = value;
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

/// <inheritdoc />
public abstract class ValueObject<T1, T2>
    : ValueObject<T1>
{
    /// <summary>
    /// Gets the second value of the value object.
    /// </summary>
    public T2 Value2 { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObject{T1, T2}"/> class.
    /// </summary>
    /// <param name="value1">The first value of the value object.</param>
    /// <param name="value2">The second value of the value object.</param>
    /// <exception cref="ArgumentNullException">Thrown if any of the values are null.</exception>
    protected ValueObject(T1 value1, T2 value2)
        : base(value1)
    {
        ObjectHelper.EnsureNotNull(value2, nameof(value2));
        Value2 = value2;
    }


    /// <inheritdoc />
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Value2;
    }
}

/// <inheritdoc />
public abstract class ValueObject<T1, T2, T3>
    : ValueObject<T1, T2>
{
    /// <summary>
    /// Gets the third value of the value object.
    /// </summary>
    public T3 Value3 { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObject{T1, T2, T3}"/> class.
    /// </summary>
    /// <param name="value1">The first value of the value object.</param>
    /// <param name="value2">The second value of the value object.</param>
    /// <param name="value3">The third value of the value object.</param>
    /// <exception cref="ArgumentNullException">Thrown if any of the values are null.</exception>
    protected ValueObject(T1 value1, T2 value2, T3 value3)
        : base(value1, value2)
    {
        ObjectHelper.EnsureNotNull(value3, nameof(value3));
        Value3 = value3;
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Value2;
        yield return Value3;
    }

}

/// <inheritdoc />
public abstract class ValueObject<T1, T2, T3, T4>
    : ValueObject<T1, T2, T3>
{
    /// <summary>
    /// Gets the fourth value of the value object.
    /// </summary>
    public T4 Value4 { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObject{T1, T2, T3, T4}"/> class.
    /// </summary>
    /// <param name="value1">The first value of the value object.</param>
    /// <param name="value2">The second value of the value object.</param>
    /// <param name="value3">The third value of the value object.</param>
    /// <param name="value4">The fourth value of the value object.</param>
    /// <exception cref="ArgumentNullException">Thrown if any of the values are null.</exception>
    protected ValueObject(T1 value1, T2 value2, T3 value3, T4 value4)
        : base(value1, value2, value3)
    {
        ObjectHelper.EnsureNotNull(value4, nameof(value4));
        Value4 = value4;
    }


    /// <inheritdoc />
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Value2;
        yield return Value3;
        yield return Value4;
    }
}

/// <inheritdoc />
public abstract class ValueObject<T1, T2, T3, T4, T5>
    : ValueObject<T1, T2, T3, T4>

{
    /// <summary>
    /// Gets the fifth value of the value object.
    /// </summary>
    public T5 Value5 { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObject{T1, T2, T3, T4, T5}"/> class.
    /// </summary>
    /// <param name="value1">The first value of the value object.</param>
    /// <param name="value2">The second value of the value object.</param>
    /// <param name="value3">The third value of the value object.</param>
    /// <param name="value4">The fourth value of the value object.</param>
    /// <param name="value5">The fifth value of the value object.</param>
    /// <exception cref="ArgumentNullException">Thrown if any of the values are null.</exception>
    protected ValueObject(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        : base(value1, value2, value3, value4)
    {
        ObjectHelper.EnsureNotNull(value5, nameof(value5));
        Value5 = value5;
    }


    /// <inheritdoc />
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Value2;
        yield return Value3;
        yield return Value4;
        yield return Value5;
    }
}
