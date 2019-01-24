using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FileDuplicator.Configuration
{
    public class AppsettingsRetriever : IPathRetriever
    {
        private readonly IConfigurationRoot confRoot;
        public AppsettingsRetriever(IConfigurationRoot configurationRoot)
        {
            confRoot = configurationRoot;
        }


        //public FileInfo GetDestinationFile(string propertyName)
        //    => ExecuteConversionFromJson<AppsettingsModel, FileInfo>(x =>
        //    {
        //        var properties = x.ConfigPaths.GetType().GetProperties();
        //        foreach (var property in properties)
        //        {
        //            if (property.Name == propertyName)
        //            {
        //                return new FileInfo(property.GetValue(x.ConfigPaths).ToString());
        //            }
        //        }
        //        return null;
        //    });

        public DirectoryInfo GetDirectory(string sectionName)
        {
            var section = confRoot.GetSection("Paths");
            var subSection = section.GetSection(sectionName);
            return new DirectoryInfo(subSection.Value);
        }



        public FileInfo GetDestinationFile(string sectionName)
        {
            var section = confRoot.GetSection("Paths");
            var subSections = section.GetChildren();
            foreach (var subSection in subSections)
            {
                if (subSection.Key == sectionName)
                {
                    return new FileInfo(subSection.Value);
                }
            }
            return null;
        }


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
