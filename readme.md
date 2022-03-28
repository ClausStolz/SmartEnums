# SmartEnums 
![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)
[![NuGet Badge](https://buildstats.info/nuget/SmartEnums)](https://www.nuget.org/packages/SmartEnums/)
[![Lates release](https://github.com/ClausStolz/SmartEnums/actions/workflows/master.yml/badge.svg)](https://github.com/ClausStolz/SmartEnums/actions/workflows/master.yml)

# Info
SmartEnums is a simple library, written in C#.NET, which enables you to enhancing the capabilities of standard `enum`.

# Installation
Either checkout this Github repository or install SmartEnums via NuGet Package Manager. 

If you want to use NuGet just search for `SmartEnums` or run the following command in the NuGet Package Manager console:

`PM> Install-Package SmartEnums`

# Usage
SmartEnums works on the basis of attributes, which means that now it becomes possible to store custom data for enumeration fields without resorting to writing classes.

### Enum Values:
- [Adding fields](#adding-fields)
- [Getting value](#getting-value)
- [Attribute versions](#attribute-versions)
- [Getting versioned value](#getting-versioned-value)
### Enum Tags:
- [Adding tags](#adding-tags-attributes)
- [Getting tags](#getting-tags)
- [Searching via tags](#searching-via-tags)
- [Searching excluding tags](#searching-excluding-tags)
### More useful features
- [Enumeration](#enumeration)
- [Metadata](#metadata)

# Adding enum value attributes
First, let's describe the enumeration we want to work with:
```csharp
public enum UserSubscription
{
  OneMonth,
  SixMonth, 
  Year,
}
```
Now using attribute 
```csharp 
EnumValueAttribute(string key, object value)
``` 
adding custom information in enumeration:

```csharp
public enum UserSubscription
{
    [EnumValue("Price", 169.0)]
    [EnumValue("Description", "One month subscribe")]
    [EnumValue("Subscribe period", 31)]
    OneMonth,
    
    [EnumValue("Price", 600.50)]
    [EnumValue("Description", "Six month subscribe")]
    [EnumValue("Subscribe period", 31 * 6)]
    SixMonth, 
    
    [EnumValue("Price", 1000.0)]
    [EnumValue("Description", "One year subscribe")]
    [EnumValue("Subscribe period", 31 * 12)]
    Year,
}
//I know that the date count is incorrect, I just gave an example that you can store any data
```
Now you add custom fields in enumeration.


An attribute can store expressions. It's means that you can hold simple value types, `typeof()` expressions and other `enum`.
```csharp
public enum Gender
{
    [EnumValue("Description", "he/him")]
    Male,
    
    [EnumValue("Description", "she/her")]
    Female,
}

public enum TemplateUser
{
    [EnumValue("Age", 20)]
    [EnumValue("Gender", Gender.Male)]
    Jhon,

    [EnumValue("Age", 25)]
    [EnumValue("Gender", Gender.Male)]
    Claus,

    [EnumValue("Age", 15)]
    [EnumValue("Gender", Gender.Female)]
    Elza
}
```

# Getting value
In order to get the value of a custom field, you need to use the extension method 

```csharp
public static T GetValueOf<T>(this Enum element, string key)
```

In order not to duplicate the code, let's take the enumeration declared above:
```csharp
var age = TemplateUser.Claus.GetValueOf<int>("Age"); //return 25
var genderDescription = TemplateUser.Claus.GetValueOf<Gender>("Gender").GetValueOf<string>("Description"); //return "he/him"
```
And now you got values of custom attribute fields.

# Attribute versions
You can add your versions for attributes using same attribute with `string version` parameter

```csharp
public enum UserSubscription
{
    [EnumValue("Price", 169.0, "1.0.0")]
    [EnumValue("Price", 300.0, "2.0.0")]
    [EnumValue("Price", 169.0, "2.0.1")]
    [EnumValue("Price", 300.0, "3.0.0")]
    OneMonth,
}
```
Versions implemented just as string type and you can make your own versions. But must remember that versions use standard strings comparison.

# Getting versioned value
In order to get the versioned value of a custom field, you need to use the same extension method like without version but add version parameter
```csharp
public static T GetValueOf<T>(this Enum element, string key, string version)
```
and get needed versioned value:

```csharp
var price = UserSubscription.OneMonth.GetValueOf<double>("Price", "1.0.0"); //return 169.0
```
If you use method `GetValueOf<T>` without version for field that has some versions it return value of newest version.

Also you can get newest versions using keyword implemented in config class.

There are two keywords for get newest versions:
```csharp
"latest",
"newest"
```

If you need to get a specific version or newer, you can use the `^` sign at the beginning of the parameter.

With this knowledge, you can get the value for the desired version.
```csharp
var priceLatest = UserSubscription.OneMonth.GetValueOf<double>("Price", "latest"); //return 300.0
var priceNewest = UserSubscription.OneMonth.GetValueOf<double>("Price", "newest"); //return 300.0
var price = UserSubscription.OneMonth.GetValueOf<double>("Price", "^2.0.0"); //return 300.0
```

# Adding tags attributes
In SmartEnums also provides work with tags. It's very useful when you need to mark certain elements of an enum with certain values. As an example, I mark items that are deprecated or that are used only in the release/debug version.

Again, let's describe the enumeration we want to work with:
```csharp
public enum UserSubscription
{
  OneMonth,
  SixMonth, 
  Year,
  TwoYears,
}
```
Now using attribute 
```csharp 
EnumTagAttribute(string value)
``` 
adding custom tag in enumeration:

```csharp
public enum UserSubscription
{
    [EnumTag("new users")]
    OneMonth,
    
    [EnumTag("new users")]
    SixMonth, 
    
    [EnumTag("deprecated")]
    Year,
    
    [EnumTag("new users")]
    [EnumTag("test")]
    TwoYears
}
```
Now you add custom tags in enumeration.

# Getting tags
In order to get tags of an enum element, you need to use the extension method 

```csharp
public static IEnumerable<string>? GetEnumTags(this Enum obj)
```

Let's take the enumeration declared above:
```csharp
var tags = UserSubscription.TwoYears.GetEnumTags(); //return { "new users", "test" }
```

# Searching via tags
For searching via tags in enum you need to use helper class `SmartEnum`. It contain overloaded method to search elements in enum whith certain tags.

```csharp
public static IEnumerable<T> FindByTag<T>(string tag)
public static IEnumerable<T> FindByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any)
```

Need to make note to flag parameter. `TagSearchFlag` has two implemented values:

```csharp
public enum TagSearchingFlag
    {
        /// <summary>
        /// Indicated to need to search elements where any
        /// tags is match with searching tags list.
        /// </summary>
        Any,
        /// <summary>
        /// Indicated to need to search elements where all
        /// tags is match with searching tags list.
        /// </summary>
        All,
    }
```

Using this flag, as you might guess from the description, you can explain how exactly searching using tags:

```csharp
var elements = SmartEnum.FindByTag<UserSubscription>("new users"); // return { OneMonth, SixMonth, TwoYears }
var elements = SmartEnum.FindByTag<UserSubscription>(new [] { "new users", "deprecated", "test" }, TagSearchingFlag.Any); // return { OneMonth, SixMonth, Year, TwoYears }
var elements = SmartEnum.FindByTag<UserSubscription>(new [] { "new users", "test" }, TagSearchingFlag.All); // return { TwoYears }
```

# Searching excluding tags
Sometimes need to searching excluding certain tags. For this situatuion `SmartEnum` contain overloaded method to search elements that excluding certain tags.
    
```csharp
public static IEnumerable<T> FindExcludingByTag<T>(string tag)
public static IEnumerable<T> FindExcludingByTag<T>(IEnumerable<string> tags, TagSearchingFlag flag = TagSearchingFlag.Any)
```

This works inversely to the overloaded method described above and next code explain it:
```csharp
var elements = SmartEnum.FindExcludingByTag<TestEnumTag>("new users"); // return { Year }
var elements = SmartEnum.FindExcludingByTag<TestEnumTag>(new [] { "new users", "test" }, TagSearchingFlag.Any); // return { Year }
var elements = SmartEnum.FindExcludingByTag<TestEnumTag>(new [] { "new users", "test" }, TagSearchingFlag.All); // return { OneMonth, SixMonth, Year }

```

# Enumeration
By default, C# does not have an enumeration for enums. I suggest this big omission and added a method that implements this functionality.

```csharp
public static IEnumerable<T> GetEnumerator<T>()

//example
public enum Gender
{
  Male,
  Female
}

var genders = SmartEnum.GetEnumerator<Gender>(); //return IEnumerable<Gender> [Male, Female]
```
# Metadata
Sometimes need get full information about used `EnumValueAttribute` in enum. For this situations you can get metadata of enum serialized to json or xml:

For get metadata in json format use next extension method:
```csharp
public static string GetJsonMetadata(this Enum obj) 
```

For get metadata in xml format use next extansion method:
```csharp
public static string GetXmlMetadata(this Enum obj)
```

### That's all Folks!
