using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    [ConfigurationCollection(typeof(ChatServerConfigurationElement), AddItemName = ItemTagName)]
    public sealed class ChatServerConfigurationElementCollection :
        ConfigurationElementCollection
    {
        private const string ItemTagName = "server";

        protected override ConfigurationElement CreateNewElement()
        {
            return new ChatServerConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ChatServerConfigurationElement)?.Address;
        }
    }
}
