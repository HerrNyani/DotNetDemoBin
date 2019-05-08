using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public sealed class TextChatConfigurationElement :
        ConfigurationElement
    {
        private const string TextColorNameAttributeName = "textColor";

        [ConfigurationProperty(TextColorNameAttributeName, DefaultValue = "white")]
        public string TextColorName
        {
            get => (string)base[TextColorNameAttributeName];
            set => base[TextColorNameAttributeName] = value;
        }
    }
}
