using Bieber.Core.ValueObjects.Base;

namespace Bieber.Core.ValueObjects.Tests;

public class ValueObjectTTests
{
    private sealed class TestValueObject : ValueObject<string>
    {
        public TestValueObject(string value) : base(value) { }
    }

    [Fact]
    public void Constructor_NullValue_ThrowsArgumentNullException()
    {
        string? value = null;
        Should.Throw<ArgumentNullException>(() => new TestValueObject(value!));
    }

    [Fact]
    public void GetAtomicValues_ReturnsValue()
    {
        var obj = new TestValueObject("test");

        obj.GetAtomicValues().ShouldContain("test");
    }
}
