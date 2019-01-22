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
        public class DirectoriesName
        {
            public const string PolandDirectory = "PL";
            public const string RomaniaDirectory = "RO";
            public const string RussiaDirectory = "RU";
            public const string DefaultDirectory = "Default";
        }
        public class AdditionalParameters
        {
            public const string BrowserLinkParameter = "-b";
        }
    }
}
