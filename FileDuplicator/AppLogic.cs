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

        public void Start(string confParams, bool isBrowserLinkEnabled)
        {
            var webConfig = isBrowserLinkEnabled ? Const.ConfigFiles.WebConfigWithBrowserLinkFileName : Const.ConfigFiles.WebConfigFileName;

            var directory = SearchForDirectory(confParams);

            //var files = SearchForFilesToCopy()

            //if(confParams.Any(x => x.ToLower() == Const.AdditionalParameters.BrowserLinkParameter.ToLower()))
            //{
            //    confModel.IsBrowserLink = true;

            //}

            var configurationChoice = "a";

            var appsettingsObj = new AppsettingsRetriever();
            var dirInfo = new DirectoryInfo(appsettingsObj.GetWebConfigFilePath());
            var directories = dirInfo.GetDirectories().Where(x => x.Name.ToLower() == configurationChoice.ToLower());

            //switch (configurationChoice.ToUpper())
            //{
            //    case "RO":
            //        CopyFile(Const.DirectoriesName.RomaniaDirectory);
            //        break;
            //    case "RU":
            //        CopyFile(Const.DirectoriesName.RussiaDirectory);
            //        break;
            //    case "PL":
            //        CopyFile(Const.DirectoriesName.PolandDirectory);
            //        break;
            //    case "DEF":
            //        CopyFile(Const.DirectoriesName.DefaultDirectory);
            //        break;
            //    default:
            //        Console.WriteLine("Typed wrong option");
            //        break;
            //}

        }

        private DirectoryInfo SearchForDirectory(string confParams)
        {
            var dirInfo = new DirectoryInfo(new AppsettingsRetriever().GetWebConfigFilePath());

            var directories = dirInfo.GetDirectories();

            var searchedDirectory = directories.Select(x => x).Where(y => y.Name.ToLower() == confParams.ToLower());

            return (searchedDirectory.Count() == 1) ? searchedDirectory.First() : throw new Exception($"Directory {confParams} not found");

        }

        public void CopyFile(string confChoice)
        {
            var appsettingsObj = new AppsettingsRetriever();

            var dirInfo = new DirectoryInfo(appsettingsObj.GetWebConfigFilePath());

            var directories = dirInfo.GetDirectories().Where(x => x.Name.ToLower() == confChoice.ToLower());

            var directory = (directories.Count() == 1) ? directories.First() : throw new Exception($"Directory {confChoice} not found, please check appsettings.json or parent directory");

            var Files = directory.GetFiles().Where(x => x.Name.ToLower() == Const.ConfigFiles.WebConfigFileName.ToLower()); ;

            var file = (Files.Count() == 1) ? Files.First() : throw new Exception($"File {Const.ConfigFiles.WebConfigFileName} not found");

           
            file.CopyTo(appsettingsObj.GetDestinationWebConfigFile(),true);

            Console.WriteLine("File copied successfully");
        }
    }
}
