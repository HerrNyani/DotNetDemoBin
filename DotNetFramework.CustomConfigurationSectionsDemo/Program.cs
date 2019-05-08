using DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo.ApplicationConfiguration.Chat;
using System;
using System.Configuration;
using System.Linq;

namespace DotNetDemoBin.DotNetFramework.CustomConfigurationSectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var chatConfig = ConfigurationManager.GetSection("chat") as ChatConfigurationSection;

            if (chatConfig == null)
            {
                Console.WriteLine("No chat section found in app.config.");
                return;
            }

            Console.WriteLine("=== Loaded configuration ===");
            Console.WriteLine("--- Text ---");
            Console.WriteLine($"Text color: {chatConfig.Text.TextColorName}");
            Console.WriteLine();

            Console.WriteLine("--- Voice ---");
            Console.WriteLine($"Activation mode: {chatConfig.Voice.ActivationModeName}");
            Console.WriteLine($"\tPush to talk key: {chatConfig.Voice.PushToTalkActivation.ActivationKeyName}");
            Console.WriteLine($"\tVoice activation threshold percentage: {chatConfig.Voice.VoiceActivation.VolumeThresholdPercentage}");
            Console.WriteLine();

            Console.WriteLine("--- Servers ---");
            foreach (var serverConfig in chatConfig.ChatServerConfigurationElementCollection
                .OfType<ChatServerConfigurationElement>())
            {
                Console.WriteLine($"\t{serverConfig.DisplayName} ({serverConfig.Address})");
            }

            Console.WriteLine();
        }
    }
}
