using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using System.IO;

namespace FileDuplicator
{
    public class AppLogic
    {

        public void Start()
        {
            Console.WriteLine("Copy config files to: {type: RO - Romania, RU - Russia, PL - Poland, DEF - default}");
            var configurationChoice = Console.ReadLine().ToUpper();

            switch (configurationChoice)
            {
                case "RO":

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

            var pathFileToConfigs = new AppsettingsRetriever().GetRomaniaConfigFolder();

            var dir = new DirectoryInfo(pathFileToConfigs);

            var file = Directory.GetFiles(pathFileToConfigs, "web.config");
            
            if(file.Length != 1)
            {
                throw new Exception("web.config not found");
            }

            File.Copy()

            File.Copy(file[0], @"d:\temp.config", true);
            File.Copy(file[0], @"d:\temp.config");

            var filepaths = Directory.GetDirectories(pathFileToConfigs);

            var txt = Directory.GetFiles(pathFileToConfigs);

            foreach (var item in txt)
            {
                Console.WriteLine(item);
                
                
            }
            Console.Read();
        }
    }
}
