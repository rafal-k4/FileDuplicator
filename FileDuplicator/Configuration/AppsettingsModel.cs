using Newtonsoft.Json;

namespace FileDuplicator.Configuration
{
    public class AppsettingsModel
    {
        [JsonProperty(propertyName: "PathFolders")]
        public ConfigFolders ConfigPathFolder { get; set; }


        public class ConfigFolders
        {
            [JsonProperty(propertyName: "ConfigPathFolder")]
            public string ConfigPathFolder { get; set; }
            [JsonProperty(propertyName: "RussiaConfigFolder")]
            public string RussiaConfigFolder { get; set; }
            [JsonProperty(propertyName: "RomaniaConfigFolder")]
            public string RomaniaConfigFolder { get; set; }
            [JsonProperty(propertyName: "PolishConfigFolder")]
            public string PolishConfigFolder { get; set; }
            [JsonProperty(propertyName: "DefaultConfigFolder")]
            public string DefaultConfigFolder { get; set; }
            [JsonProperty(propertyName: "DestinationConfigFile")]
            public string DestinationConfigFile { get; set; }
        }
    }
}
