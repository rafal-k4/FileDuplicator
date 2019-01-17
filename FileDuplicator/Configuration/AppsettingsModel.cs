using Newtonsoft.Json;

namespace FileDuplicator.Configuration
{
    public class AppsettingsModel
    {
        [JsonProperty(propertyName: "WebConfigPaths")]
        public ConfigFolders ConfigPathFolder { get; set; }


        public class ConfigFolders
        {
            [JsonProperty(propertyName: "WebConfigPathFolder")]
            public string ConfigPathFolder { get; set; }

            [JsonProperty(propertyName: "DestinationWebConfigFile")]
            public string DestinationConfigFile { get; set; }
        }
    }
}
