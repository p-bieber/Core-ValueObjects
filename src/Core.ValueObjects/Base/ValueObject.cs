namespace Bieber.Core.ValueObjects.Base;
/// <summary>
/// Represents a base class for value objects in the domain.
/// Value objects are immutable and are compared based on their properties.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the atomic values of the value object.
    /// </summary>
    /// <returns>An enumerable of the atomic values.</returns>
    public abstract IEnumerable<object> GetAtomicValues();

    /// <summary>
    /// Checks if the atomic values of this value object are equal to another value object's atomic values.
    /// </summary>
    /// <param name="other">The other value object to compare with.</param>
    /// <returns>True if the atomic values are equal, otherwise false.</returns>
    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    /// <summary>
    /// Checks if this value object is equal to another value object.
    /// </summary>
    /// <param name="other">The other value object to compare with.</param>
    /// <returns>True if the value objects are equal, otherwise false.</returns>
    public virtual bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }
}
