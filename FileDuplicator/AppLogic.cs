using System;
using System.Collections.Generic;
using System.Text;
using FileDuplicator.Configuration;
using System.IO;
using System.Linq;

namespace FileDuplicator
{
    public class AppLogic : IAppLogic
    {
        private IPathRetriever pathRetriever;

        public AppLogic(IPathRetriever pathRetriever)
        {
            this.pathRetriever = pathRetriever;
        }

        public void Start(string confParams, bool isBrowserLinkEnabled)
        {

            var webConfig = isBrowserLinkEnabled ? Const.ConfigFiles.WebConfigWithBrowserLinkFileName : Const.ConfigFiles.WebConfigFileName;


            //get Folder from which files will be copied
            var chosenDirectoryPath = pathRetriever.GetDirectory().GetDirectories().GetSpecifiedDirectory(webConfig);

            //get webconfig and appconfig file to copy
            var webConfigPath = chosenDirectoryPath.GetFiles().GetSpecifiedFile(webConfig);
            var appConfigPath = chosenDirectoryPath.GetFiles().GetSpecifiedFile(Const.ConfigFiles.AppConfigFileName);

            //copy files to destined folder
            CopyFile(webConfigPath, pathRetriever.GetDestinationFile(webConfig).Name);


            //var directoryConfig = pathRetriever.GetDirectory().GetDirectories();

            //var directory = SearchForDirectory(confParams);



            //var configurationChoice = "a";

            //var appsettingsObj = new AppsettingsRetriever();
            //var dirInfo = new DirectoryInfo(appsettingsObj.GetWebConfigFilePath());
            //var directories = dirInfo.GetDirectories().Where(x => x.Name.ToLower() == configurationChoice.ToLower());



        }

        //private DirectoryInfo SearchForDirectory(string confParams)
        //{
        //    var dirInfo = new DirectoryInfo(pathRetriever.GetDirectory());

        //    var directories = dirInfo.GetDirectories();

        //    var searchedDirectory = directories.Select(x => x).Where(y => y.Name.ToLower() == confParams.ToLower());

        //    return (searchedDirectory.Count() == 1) ? searchedDirectory.First() : throw new Exception($"Directory {confParams} not found");

        //}

        public void CopyFile(FileInfo file, string copyToPath)
        {
            //var appsettingsObj = new AppsettingsRetriever();

            //var dirInfo = new DirectoryInfo(appsettingsObj.GetWebConfigFilePath());

            //var directories = dirInfo.GetDirectories().Where(x => x.Name.ToLower() == confChoice.ToLower());

            //var directory = (directories.Count() == 1) ? directories.First() : throw new Exception($"Directory {confChoice} not found, please check appsettings.json or parent directory");

            //var Files = directory.GetFiles().Where(x => x.Name.ToLower() == Const.ConfigFiles.WebConfigFileName.ToLower()); ;

            //var file = (Files.Count() == 1) ? Files.First() : throw new Exception($"File {Const.ConfigFiles.WebConfigFileName} not found");

            file.CopyTo(copyToPath, true);
           
            //file.CopyTo(appsettingsObj.GetDestinationWebConfigFile(),true);

            //Console.WriteLine("File copied successfully");
        }
    }
}
