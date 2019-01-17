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
        public string GetConfigFilePath()
        => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.ConfigPathFolder);

        public string GetPolishConfigFolder()
            => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.PolishConfigFolder);

        public string GetRussiaConfigFolder()
            => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.RussiaConfigFolder);

        public string GetRomaniaConfigFolder()
            => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.RomaniaConfigFolder);

        public string GetDefaultConfigFolder()
            => Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.DefaultConfigFolder);



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
