using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace FileDuplicator.Configuration
{
    public class AppsettingsRetriever
    {
        public string GetWebConfigFilePath()
        => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.ConfigPathFolder);

        public string GetDestinationWebConfigFile()
        => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.DestinationConfigFile);

        public IEnumerable<string> GetAllConfigFolder()
            => Execute<AppsettingsModel, IEnumerable<string>>(x =>
                new string[] 
                {
                    x.ConfigPathFolder.ConfigPathFolder,
                    x.ConfigPathFolder.DestinationConfigFile
                }
            );

        private U Execute<T, U>(Func<T,U> func)
        {
            string appsettingsFileContent = string.Empty;

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");

            var appRootPath = appPathMatcher.Match(path).Value;

            //string path = Environment.CurrentDirectory;
            try
            {
                path = Path.Combine(appRootPath, "appsettings.json");
                var sr = new StreamReader(path);
                appsettingsFileContent = sr.ReadToEnd();
            }
            catch (Exception)
            {
                Console.WriteLine("appsettings.json doesnt exist or is corrupted");
                throw;
            }
            
            var obj = JsonConvert.DeserializeObject<T>(appsettingsFileContent);

            return func.Invoke(obj);
        }

    }
}
