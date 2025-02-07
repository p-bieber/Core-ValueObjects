# Bieber.Core.ValueObjects

`Bieber.Core.ValueObjects` is a library for creating and managing value objects in your .NET applications. It provides a base implementation for value objects that are immutable and compared based on their properties.

## Features

- Base classes for value objects with one to five properties
- Validation support using FluentValidation
- Easy to extend and customize

## Installation

Add the `Bieber.Core.ValueObjects` library to your project using the .NET CLI:

```sh
dotnet add package Bieber.Core.ValueObjects

```
Or add the package reference directly in your .csproj file:
```xml
<PackageReference Include="Bieber.Core.ValueObjects" Version="1.0.0" />

```


## Usage

To create a value object, inherit from one of the base classes provided by the library and implement the required methods. For example:

```c#
using Bieber.Core.ValueObjects.Base; 
using FluentValidation;

public class EmailValueObject : ValidatedValueObject<string>
{ 
	public EmailValueObject(string value, bool throwExceptionOnFailure = true) 
	: base(value, throwExceptionOnFailure) 
	{ }

	protected override IEnumerable<IValidator<string>> RegisterValidators()
	{
		yield return new InlineValidator<string>()
			{
				v => v.RuleFor(x => x).EmailAddress()
			};
	}
}

```

## License

This project is licensed under the MIT License. For more information, please see the LICENSE file.
It also includes software under the Apache 2.0 License:
- FluentValidation

## Contributions

We welcome contributions to improve this library. Please fork the repository and submit pull requests with your changes.
