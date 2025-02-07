using Bieber.Core.ValueObjects.Base;
using FluentValidation;

namespace Bieber.Core.ValueObjects.Tests;

public class ValidatedValueObjectTests
{
    private sealed class EmailValueObject : ValidatedValueObject<string>
    {
        public EmailValueObject(string value, bool throwExceptionOnFailure = true)
            : base(value, throwExceptionOnFailure) { }

        public List<IValidator<string>> GetValidators() => Validators;
        protected override IEnumerable<IValidator<string>> RegisterValidators()
        {
            yield return new InlineValidator<string>()
            {
                v => v.RuleFor(x => x).EmailAddress()
            };
        }
    }

    private sealed class FullNameValueObject : ValidatedValueObject<string>
    {
        public FullNameValueObject(string value, bool throwExceptionOnFailure = true)
            : base(value, throwExceptionOnFailure) { }
        public List<IValidator<string>> GetValidators() => Validators;
        protected override IEnumerable<IValidator<string>> RegisterValidators()
        {
            yield return new InlineValidator<string>()
            {
                v => v.RuleFor(x => x).MaximumLength(50)
            };
        }
    }

    private sealed class PersonValueObject : ValidatedValueObject<string, int>
    {
        public PersonValueObject(string name, int age, bool throwExceptionOnFailure = true)
            : base(name, age, throwExceptionOnFailure) { }
        public List<IValidator<string>> GetValidators1() => Validators1;
        public List<IValidator<int>> GetValidators2() => Validators2;
        protected override IEnumerable<IValidator<string>> RegisterValidators1()
        {
            yield return new InlineValidator<string>()
            {
                v => v.RuleFor(x => x).NotEmpty()
            };
        }

        protected override IEnumerable<IValidator<int>> RegisterValidators2()
        {
            yield return new InlineValidator<int>()
            {
                v => v.RuleFor(x => x).InclusiveBetween(0, 120)
            };
        }
    }

    [Fact]
    public void EmailValueObject_ValidEmail_DoesNotThrow()
    {
        var obj = new EmailValueObject("test@example.com");

        obj.ShouldNotBeNull();
    }

    [Fact]
    public void EmailValueObject_InvalidEmail_ThrowsValidationException()
    {
        Should.Throw<ValidationException>(() => new EmailValueObject("invalid-email"));
    }

    [Fact]
    public void FullNameValueObject_ValidFullName_DoesNotThrow()
    {
        var obj = new FullNameValueObject("John Doe");

        obj.ShouldNotBeNull();
    }

    [Fact]
    public void FullNameValueObject_InvalidFullName_ThrowsValidationException()
    {
        Should.Throw<ValidationException>(() => new FullNameValueObject(new string('a', 51)));
    }

    [Fact]
    public void PersonValueObject_ValidPerson_DoesNotThrow()
    {
        var obj = new PersonValueObject("John Doe", 30);

        obj.ShouldNotBeNull();
    }

    [Fact]
    public void PersonValueObject_InvalidName_ThrowsValidationException()
    {
        Should.Throw<ValidationException>(() => new PersonValueObject("", 30));
    }

    [Fact]
    public void PersonValueObject_InvalidAge_ThrowsValidationException()
    {
        Should.Throw<ValidationException>(() => new PersonValueObject("John Doe", 130));
    }

    [Fact]
    public void EmailValueObject_ValidatorsCount_IsOne()
    {
        var obj = new EmailValueObject("test@example.com");
        obj.GetValidators().Count.ShouldBe(1);
    }

    [Fact]
    public void FullNameValueObject_ValidatorsCount_IsOne()
    {
        var obj = new FullNameValueObject("John Doe");
        obj.GetValidators().Count.ShouldBe(1);
    }

    [Fact]
    public void PersonValueObject_ValidatorsCount_IsOneForEach()
    {
        var obj = new PersonValueObject("John Doe", 30);
        obj.GetValidators1().Count.ShouldBe(1);
        obj.GetValidators2().Count.ShouldBe(1);
    }
}
