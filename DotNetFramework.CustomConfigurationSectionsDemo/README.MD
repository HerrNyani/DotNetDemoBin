Custom configuration sections for app.config and web.config
===========================================================

This demo shows how to define, map and access a custom app.config section.

Requirements
------------
* .NET Framework 2.0 or later, or .NET Core 2.0 or later.

Keystones
---------
* [`ApplicationConfiguration.Chat` namespace](ApplicationConfiguration/Chat): Contains all related classes for the custom section.
    - [ChatConfigurationSection.cs](ApplicationConfiguration/Chat/ChatConfigurationSection.cs): The top-level accessor to the custom section.
* [App.config](App.config): The XML settings file.
    - `configSections` tag: Definitions of the links between the XML sections and the `ConfigurationSection` classes.

Mapping classes
---------------
### [`ConfigurationSection`](https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationsection)
Base class for a new section. Acts as the top level item. The class mapping onto your custom section must inherit from `ConfigurationSection`.

### [`ConfigurationElement`](https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationelement)
Every unique child tag needs a matching `ConfigurationElement`.

### [`ConfigurationElementCollection`](https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationelementcollection)
If a tag is a container for a list of identical child elements, you should use the `ConfigurationElementCollection` as base class instead. Additionally, you must add the `ConfigurationCollection` attribute, connecting the collection to its item type.
```csharp
[ConfigurationCollection(typeof(ChatServerConfigurationElement), AddItemName = "server")]
public sealed class ChatServerConfigurationElementCollection : ConfigurationElementCollection {}
```

### Create and decorate properties with `ConfigurationPropertyAttribute`
For each attribute and child node:
1. Create a new property.
2. Attach a `ConfigurationPropertyAttribute`, linking the property to the XML attribute or tag.
```csharp
[ConfigurationProperty("activationKey")]
public string ActivationKeyName { get; set }
```
3. Use `ConfigurationElement.operator[]` in the getter and setter bodies to access the value. 
   If the property links to a `ConfigurationElementCollection`, only the getter is required.
```csharp
public string ActivationKeyName
{
    get => (string)base[ActivationKeyAttributeName];
    set => base[ActivationKeyAttributeName] = value;
}
```

Declaring the custom section in the config file
-----------------------------------------------
In order to enable a custom section, it must be defined in the [`configSections` tag](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/configsections-element-for-configuration).
This tag is required to be the first tag in the configuration file. It connects the tag to its `ConfigurationSection` class.
```xml
<configuration>
  <configSections>
    <section name="chat" type="Framework.CustomConfigurationSectionDemo.Configurations.Chat.ChatConfigurationSection, Framework.CustomConfigurationSectionDemo"/>
  </configSections>
</configuration>
```