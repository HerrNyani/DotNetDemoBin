using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public sealed class ChatConfigurationSection :
        ConfigurationSection
    {
        private const string TextChatElementTagName = "text";
        private const string VoiceChatElementTagName = "voice";
        private const string ServerCollectionElementTagName = "servers";

        [ConfigurationProperty(TextChatElementTagName, IsRequired = true)]
        public TextChatConfigurationElement Text
        {
            get => (TextChatConfigurationElement)base[TextChatElementTagName];
            set => base[TextChatElementTagName] = value;
        }

        [ConfigurationProperty(VoiceChatElementTagName, IsRequired = true)]
        public VoiceChatConfigurationElement Voice
        {
            get => (VoiceChatConfigurationElement)base[VoiceChatElementTagName];
            set => base[VoiceChatElementTagName] = value;
        }

        [ConfigurationProperty(ServerCollectionElementTagName, IsRequired = true)]
        public ChatServerConfigurationElementCollection ChatServerConfigurationElementCollection =>
            (ChatServerConfigurationElementCollection)base[ServerCollectionElementTagName];
    }
}
