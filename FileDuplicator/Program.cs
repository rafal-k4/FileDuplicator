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
            var di = new DependencyInjection();
            di.Builder();

            var obj = di.ServiceProvider.GetService(typeof(AppLogic)) as AppLogic;
            obj.Start(args[0],false);
            
            

            Parser.Default.ParseArguments<Option>(args).
                WithParsed(x =>
                {
                    //var appLogic = new AppLogic(new AppsettingsRetriever());
                    //appLogic.Start(x.ChosenFolder.First(), x.IsBrowserLink);
                });
            
        }
    }

}
