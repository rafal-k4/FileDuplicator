using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using Newtonsoft.Json;
using System.IO;

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

            string path = Environment.CurrentDirectory;
            try
            {
                var sr = new StreamReader(path + @"\appsettings.json");
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
