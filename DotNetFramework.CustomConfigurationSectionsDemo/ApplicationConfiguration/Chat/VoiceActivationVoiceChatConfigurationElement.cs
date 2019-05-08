using System.Configuration;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat
{
    public sealed class VoiceActivationVoiceChatConfigurationElement :
        ConfigurationElement
    {
        private const string VolumeThresholdPercentageAttributeName = "volumeThresholdPercentage";

        [ConfigurationProperty(VolumeThresholdPercentageAttributeName, DefaultValue = 50)]
        [IntegerValidator(MinValue = 0, MaxValue = 100, ExcludeRange = false)]
        public int VolumeThresholdPercentage
        {
            get => (int)base[VolumeThresholdPercentageAttributeName];
            set => base[VolumeThresholdPercentageAttributeName] = value;
        }
    }
}
