using System;
using System.Collections.Generic;
using System.Text;

namespace FileDuplicator.Configuration
{
    public class Const
    {
        public class ConfigFiles
        {
            public const string WebConfigFileName = "Web.config";
            public const string AppConfigFileName = "App.config";
            public const string WebConfigWithBrowserLinkFileName = "WebB.config";
        }

        public class AppsettingsJsonSection
        {
            public const string ConfigFolderSectionName = "WebConfigPathFolder";
            public const string DestinationWebConfigFileSectionName = "DestinationWebConfigFile";
            public const string DestinationTranslationAppConfigFileSectionName = "DestinationTranslationAppConfigFile";
        }

        public class Aliases
        {
            public const string ForDefault = "def";
        }
    }
}
