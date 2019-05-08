using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public sealed class PushToTalkActivationVoiceChatConfigurationElement :
        ConfigurationElement
    {
        private const string ActivationKeyAttributeName = "activationKey";

        [ConfigurationProperty(ActivationKeyAttributeName, DefaultValue = "v")]
        public string ActivationKeyName
        {
            get => (string)base[ActivationKeyAttributeName];
            set => base[ActivationKeyAttributeName] = value;
        }
    }
}
