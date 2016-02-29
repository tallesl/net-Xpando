# ToExpando

[![][build-img]][build]
[![][nuget-img]][nuget]

Creates a [ExpandoObject] out of a given object.

## Usage

```cs
using ToExpando;

var boringUser = new User { Name ="John Smith" };

dynamic coolUser = boringUser.ToExpando();
coolUser.NickName = "Johny";
```

[build]:     https://ci.appveyor.com/project/TallesL/ConnectionTester
[build-img]: https://ci.appveyor.com/api/projects/status/github/tallesl/ConnectionTester

[nuget]:     http://badge.fury.io/nu/ConnectionTester
[nuget-img]: https://badge.fury.io/nu/ConnectionTester.png

[ExpandoObject]: https://msdn.microsoft.com/library/System.Dynamic.ExpandoObject