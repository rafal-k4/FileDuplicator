using System.IO;

namespace FileDuplicator
{
    public interface IAppLogic
    {
        void CopyFile(FileInfo file, string copyToPath);
        void Start(string confParams, bool isBrowserLinkEnabled);
    }
}