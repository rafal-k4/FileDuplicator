using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileDuplicator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Parser.Default.ParseArguments<Option>(args).
                WithParsed(x =>
                {
                    var appLogic = new AppLogic();
                    appLogic.Start(x.ChosenFolder.First(), x.IsBrowserLink);
                });
            
        }
    }

}
