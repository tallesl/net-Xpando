# To Expando

[![][build-img]][build]
[![][nuget-img]][nuget]

Creates a [ExpandoObject] out of a given object.

[build]:     https://ci.appveyor.com/project/TallesL/ConnectionTester
[build-img]: https://ci.appveyor.com/api/projects/status/github/tallesl/ConnectionTester

[nuget]:     http://badge.fury.io/nu/ConnectionTester
[nuget-img]: https://badge.fury.io/nu/ConnectionTester.png

[ExpandoObject]: https://msdn.microsoft.com/library/System.Dynamic.ExpandoObject

## Usage

```cs
using ToExpando;

var user = new User("John Smith", new DateTime(1970, 1, 1));

dynamic expando = user.ToExpando();
expando.DynamicallyCreatedProperty = "foo bar";
```
