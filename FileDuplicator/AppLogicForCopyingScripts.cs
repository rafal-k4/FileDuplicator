using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileDuplicator.Configuration;

namespace FileDuplicator
{
    public class AppLogicForCopyingScripts : IAppLogic
    {
        private IPathRetriever pathRetriever;

        public AppLogicForCopyingScripts(IPathRetriever pathRetriever)
        {
            this.pathRetriever = pathRetriever;
        }
        

        public void Start(string folderName, bool reverse)
        {

            var chosenDirectoryPath = pathRetriever.GetDirectory(Const.AppsettingsJsonSection.FolderWithScripts)
                .GetDirectories().GetSpecifiedDirectory(folderName);


            var allFiles = chosenDirectoryPath.GetFiles();

            var destinationDirectoryPath = pathRetriever.GetDirectory(Const.AppsettingsJsonSection.DestinationFolderWithScripts);
            foreach (var file in allFiles)
            {
                CopyFile(file, Path.Combine(destinationDirectoryPath.FullName, file.Name));
            }

        }
        public void CopyFile(FileInfo file, string copyToPath)
        {
            file.CopyTo(copyToPath, true);
        }
    }
}
