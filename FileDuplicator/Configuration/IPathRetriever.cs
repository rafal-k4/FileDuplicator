using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileDuplicator.Configuration
{
    public interface IPathRetriever
    {
        DirectoryInfo GetDirectory(string sectionName);
        FileInfo GetDestinationFile(string sectionName);
    }
}
