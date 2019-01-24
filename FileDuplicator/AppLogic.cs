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

        public void Start(string folderName, bool isBrowserLinkEnabled)
        {

            var webConfig = isBrowserLinkEnabled ? Const.ConfigFiles.WebConfigWithBrowserLinkFileName : Const.ConfigFiles.WebConfigFileName;


            //get Folder from which files will be copied
            var chosenDirectoryPath = pathRetriever.GetDirectory().GetDirectories().GetSpecifiedDirectory(folderName);

            //get webconfig and appconfig file to copy
            var webConfigPath = chosenDirectoryPath.GetFiles().GetSpecifiedFile(webConfig);
            var appConfigPath = chosenDirectoryPath.GetFiles().GetSpecifiedFile(Const.ConfigFiles.AppConfigFileName);

            //copy files to destined folder
            CopyFile(webConfigPath, pathRetriever.GetDestinationFile(webConfig).FullName);
            CopyFile(appConfigPath, pathRetriever.GetDestinationFile(Const.ConfigFiles.AppConfigFileName).FullName);
        }

        public void CopyFile(FileInfo file, string copyToPath)
        {
           
            file.CopyTo(copyToPath, true);
           
        }
    }
}
