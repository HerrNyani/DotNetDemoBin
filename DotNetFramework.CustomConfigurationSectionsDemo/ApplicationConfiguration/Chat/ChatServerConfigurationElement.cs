using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public sealed class ChatServerConfigurationElement :
        ConfigurationElement
    {
        private const string DisplayNameAttributeName = "displayName";
        private const string AddressNameAttributeName = "address";

        [ConfigurationProperty(DisplayNameAttributeName)]
        public string DisplayName
        {
            get => (string)base[DisplayNameAttributeName];
            set => base[DisplayNameAttributeName] = value;
        }
        [ConfigurationProperty(AddressNameAttributeName)]
        public string Address
        {
            get => (string)base[AddressNameAttributeName];
            set => base[AddressNameAttributeName] = value;
        }
    }
}
