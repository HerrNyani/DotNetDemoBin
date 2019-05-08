using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public class VoiceChatConfigurationElement :
        ConfigurationElement
    {
        private const string ActivationModeNameAttributeName = "activationMode";
        private const string PushToTalkActivationTagName = "pushToTalkActivation";
        private const string VoiceActivationTagName = "voiceActivation";

        [ConfigurationProperty(ActivationModeNameAttributeName, IsRequired = true)]
        public string ActivationModeName
        {
            get => (string)base[ActivationModeNameAttributeName];
            set => base[ActivationModeNameAttributeName] = value;
        }

        [ConfigurationProperty(PushToTalkActivationTagName, IsRequired = true)]
        public PushToTalkActivationVoiceChatConfigurationElement PushToTalkActivation
        {
            get => (PushToTalkActivationVoiceChatConfigurationElement)base[PushToTalkActivationTagName];
            set => base[PushToTalkActivationTagName] = value;
        }

        [ConfigurationProperty(VoiceActivationTagName, IsRequired = true)]
        public VoiceActivationVoiceChatConfigurationElement VoiceActivation
        {
            get => (VoiceActivationVoiceChatConfigurationElement)base[VoiceActivationTagName];
            set => base[VoiceActivationTagName] = value;
        }
    }
}
