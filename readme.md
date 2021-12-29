# SmartEnums 

## Info
SmartEnums is a simple library, written in C#.NET, which enables you to enhancing the capabilities of standard `enum`.

## Installation
Either checkout this Github repository or install SmartEnums via NuGet Package Manager. 

If you want to use NuGet just search for "SmartEnums" or run the following command in the NuGet Package Manager console:

`PM> Install-Package SmartEnums`

## Usage
SmartEnums works on the basis of attributes, which means that now it becomes possible to store custom data for enumeration fields without resorting to writing classes.


### Adding fields
First, let's describe the enumeration we want to work with:
```csharp
public enum UserSubscription
{
  OneMonth,
  SixMonth, 
  Year,
}
```
Now using attribute `EnumValueAttribute(string key, object value)` adding custom information in enumeration:
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


An attribute can store not only value types, but also more complex structures.
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

### Getting value
In order to get the value of a custom field, you need to use the extension method 

`public static T GetValueOf<T>(this Enum element, string key)`

In order not to duplicate the code, let's take the enumeration declared above:
```csharp
var age = TemplateUser.Claus.GetValueOf<int>("Age");
var genderDescription = TemplateUser.Claus.GetValueOf<Gender>("Gender").GetValueOf<string>("Description");
```
And now you got values of custom attribute fields.


That's all Folks!
