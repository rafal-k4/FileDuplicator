using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;




namespace FileDuplicator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var di = new DependencyInjection();
            di.Builder();

            Parser.Default.ParseArguments<Option>(args).
                WithParsed(x =>
                {
                    var appLogic = di.ServiceProvider.GetService<IAppLogic>();
                    appLogic.Start(x.ChosenFolder.First(), x.IsBrowserLink);
                });
            
        }
    }

}
