using Bieber.Core.ValueObjects.Base;

namespace Bieber.Core.ValueObjects.Tests;

public class ValueObjectTests
{
    private sealed class TestValueObject : ValueObject
    {
        public int Value { get; }

        public TestValueObject(int value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }

    [Fact]
    public void Equals_SameValues_ReturnsTrue()
    {
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        obj1.Equals(obj2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(2);

        obj1.Equals(obj2).ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_SameValues_ReturnsSameHashCode()
    {
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        obj1.GetHashCode().ShouldBe(obj2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentValues_ReturnsDifferentHashCodes()
    {
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(2);

        obj1.GetHashCode().ShouldNotBe(obj2.GetHashCode());
    }
}
