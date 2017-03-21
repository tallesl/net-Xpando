<p align="center">
    <a href="#xpando">
        <img alt="logo" src="Assets/logo-200x200.png">
    </a>
</p>

# Xpando

[![][build-img]][build]
[![][nuget-img]][nuget]

Utilities for dealing with [ExpandoObject].

[build]:         https://ci.appveyor.com/project/TallesL/net-xpando
[build-img]:     https://ci.appveyor.com/api/projects/status/github/tallesl/net-xpando?svg=true
[nuget]:         https://www.nuget.org/packages/Xpando
[nuget-img]:     https://badge.fury.io/nu/Xpando.svg
[ExpandoObject]: https://msdn.microsoft.com/library/System.Dynamic.ExpandoObject

## Converting an object

```cs
using XpandoLibrary;

var boringUser = new { Name ="John Smith" };
dynamic coolUser = boringUser.ToExpando(); // does the magic

coolUser.NickName = "Johny";
```

## Checking if has any property

```cs
using XpandoLibrary;

var expando = new ExpandoObject();
dynamic dynamic = expando;

expando.Empty(); // True

dynamic.Foo = "Bar";

expando.Empty(); // False
```

## Checking if has a specific property

```cs
using XpandoLibrary;

var expando = new ExpandoObject();
dynamic dynamic = expando;

dynamic.Foo = "Bar";

expando.HasProperty("Foo"); // True
expando.HasProperty("Qux"); // False
```

## Removing a property

```cs
using XpandoLibrary;

var expando = new ExpandoObject();
dynamic dynamic = expando;

dynamic.Foo = "Bar";           // creates the property
expando.RemoveProperty("Foo"); // removes the property
```

## Making a copy

```cs
using XpandoLibrary;

var expando = new ExpandoObject();

// (some initialization with nested ExpandoObject)

expando.ShallowCopy(); // creates a shallow copy of object (doesn't copy nested ExpandoObject)
expando.DeepCopy();    // creates a deep copy of object (copies nested ExpandoObject)
```