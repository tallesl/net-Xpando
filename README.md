<p align="center">
    <a href="#xpando">
        <img alt="logo" src="Assets/logo-200x200.png">
    </a>
</p>

# Xpando

[![][build-img]][build]
[![][nuget-img]][nuget]

Creates a [ExpandoObject] out of a given object.

[build]:         https://ci.appveyor.com/project/TallesL/net-xpando
[build-img]:     https://ci.appveyor.com/api/projects/status/github/tallesl/net-xpando?svg=true
[nuget]:         https://www.nuget.org/packages/Xpando
[nuget-img]:     https://badge.fury.io/nu/Xpando.svg
[ExpandoObject]: https://msdn.microsoft.com/library/System.Dynamic.ExpandoObject

## Usage

```cs
using XpandoLibrary;

var boringUser = new User { Name ="John Smith" };
dynamic coolUser = boringUser.ToExpando();

coolUser.NickName = "Johny";
```