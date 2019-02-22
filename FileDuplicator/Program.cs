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


            Parser.Default.ParseArguments<Option, UnitTestScripts>(args).
                MapResult((Option opt) => 
                {
                    di.Builder(DependencyInjection.StrategyOption.WebConfig);

                    var appLogic = di.ServiceProvider.GetService<IAppLogic>();
                    appLogic.Start(opt.ChosenFolder.First(), opt.IsBrowserLink);

                    return 0;
                },
                (UnitTestScripts scr) =>
                {
                    di.Builder(DependencyInjection.StrategyOption.UnitTestScripts);

                    var appLogic = di.ServiceProvider.GetService<IAppLogic>();
                    appLogic.Start(scr.ScriptsFolderName, false);

                    return 0;
                }, 
                errs => 1);


            //Parser.Default.ParseArguments<UnitTestScripts>(args).
            //   WithParsed( x => 
            //   {
            //       di.Builder(DependencyInjection.StrategyOption.UnitTestScripts);

            //       var appLogic = di.ServiceProvider.GetService<IAppLogic>();
            //       appLogic.Start("abc", true);

            //       Environment.Exit(0);
            //   });

            //Parser.Default.ParseArguments<Option>(args).
            //    WithParsed(x =>
            //    {
            //        di.Builder(DependencyInjection.StrategyOption.WebConfig);

            //        var appLogic = di.ServiceProvider.GetService<IAppLogic>();
            //        appLogic.Start(x.ChosenFolder.First(), x.IsBrowserLink);

            //        Environment.Exit(0);
            //    });
            
        }
    }

}
