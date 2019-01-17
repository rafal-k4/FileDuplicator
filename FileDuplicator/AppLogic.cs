using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using System.IO;
using System.Linq;

namespace FileDuplicator
{
    public class AppLogic
    {

        public void Start()
        {
            Console.WriteLine("Copy config files from: {type: RO - Romania, RU - Russia, PL - Poland, DEF - default}");
            var configurationChoice = Console.ReadLine().ToUpper();

            switch (configurationChoice)
            {
                case "RO":
                    CopyFile(configurationChoice);
                    break;
                case "RU":

                    break;
                case "PL":

                    break;
                case "DEF":

                    break;
                default:
                    break;
            }

        }

        public void CopyFile(string confChoice)
        {
            var dirInfo = new DirectoryInfo(new AppsettingsRetriever().GetWebConfigFilePath());

            var directories = dirInfo.GetDirectories().Where(x => x.Name == confChoice);

            if(directories.Count() != 1)
            {
                throw new Exception($"Directory {confChoice} not found, please check appsettings.json or parent directory");
            }



            //File.Copy(file[0], @"d:\temp.config", true);
            //File.Copy(file[0], @"d:\temp.config");



            //var dir = new DirectoryInfo(configFilePath);

            //var file = Directory.GetFiles(configFilePath, "web.config");

            //if (file.Length != 1)
            //{
            //    throw new Exception("web.config not found");
            //}

            ////File.Copy()

            //File.Copy(file[0], @"d:\temp.config", true);
            //File.Copy(file[0], @"d:\temp.config");

            //var filepaths = Directory.GetDirectories(configFilePath);

            //var txt = Directory.GetFiles(configFilePath);

            //foreach (var item in txt)
            //{
            //    Console.WriteLine(item);


            //}
            Console.Read();
        }
    }
}
