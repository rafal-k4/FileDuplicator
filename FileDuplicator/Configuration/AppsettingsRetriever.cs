using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace FileDuplicator.Configuration
{
    public class AppsettingsRetriever : IPathRetriever
    {


        public DirectoryInfo GetDirectory()
            => ExecuteConversionFromJson<AppsettingsModel, DirectoryInfo>(x => new DirectoryInfo(x?.ConfigPaths.ConfigPathFolder));

        //public FileInfo GetDestinationFile(string fileName)
        //    => Execute<AppsettingsModel, FileInfo>(x => new FileInfo(x?.ConfigPathFolder.DestinationWebConfigFile));

        public FileInfo GetDestinationFile(string fileName)
            => ExecuteConversionFromJson<AppsettingsModel, FileInfo>(x =>
            {
                var properties = x.ConfigPaths.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var prop = property.GetValue(x.ConfigPaths).ToString();
                    if (prop.ToLower() == fileName.ToLower())
                        return new FileInfo(prop);

                }
                return null;
            });




        //public string GetWebConfigFilePath()
        //=> Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.ConfigPathFolder);

        //public string GetDestinationWebConfigFile()
        //=> Execute<AppsettingsModel, string>(x => x?.ConfigPathFolder?.DestinationConfigFile);



        private U ExecuteConversionFromJson<T, U>(Func<T, U> func)
        {
            string appsettingsFileContent = string.Empty;

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");

            var appRootPath = appPathMatcher.Match(path).Value;

            path = Path.Combine(appRootPath, "appsettings.json");
            //string path = Environment.CurrentDirectory;
            try
            {
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

    //interface ITest
    //{
    //    T Execute<T, U>(Func<T, U> func);
    //}
}
