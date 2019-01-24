using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FileDuplicator
{
    public static class Helper
    {

        public static DirectoryInfo GetSpecifiedDirectory(this DirectoryInfo[] directoriesInfo, string specifiedFolderName)
        {
            var directory = directoriesInfo.Select(x => x).Where(x => x.Name.ToLower() == specifiedFolderName.ToLower().Trim());

            return (directory?.Count() == 1) ? directory.First() : throw new Exception("folder not found");
        }

        public static FileInfo GetSpecifiedFile(this FileInfo[] filesInfo, string specifiedFileName)
        {
            var file = filesInfo.Select(x => x).Where(x => x.Name.ToLower() == specifiedFileName.ToLower().Trim());

            return (file?.Count() == 1) ? file.First() : throw new Exception("folder not found");
        }
    }
}
