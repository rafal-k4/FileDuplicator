using Newtonsoft.Json;

namespace FileDuplicator.Configuration
{
    public class AppsettingsModel
    {
        [JsonProperty(propertyName: "Paths")]
        public ConfigPath ConfigPaths { get; set; }


        public class ConfigPath
        {
            [JsonProperty(propertyName: "WebConfigPathFolder")]
            public string ConfigPathFolder { get; set; }

            [JsonProperty(propertyName: "DestinationWebConfigFile")]
            public string DestinationWebConfigFile { get; set; }

            [JsonProperty(propertyName: "DestinationTranslationAppConfigFile")]
            public string DestinationTranslationAppConfigFile { get; set; }
        }
    }
}
