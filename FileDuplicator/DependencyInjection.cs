using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using FileDuplicator.Configuration;

namespace FileDuplicator
{
    public class DependencyInjection
    {
        IServiceCollection service;
        public IServiceProvider ServiceProvider { get; set; }

        public DependencyInjection()
        {
            //create a list of dependencies
            service = new ServiceCollection();
        }

        public enum StrategyOption { WebConfig, UnitTestScripts }

        public void Builder(StrategyOption strategyOption)
        {
            //at this point all dependencies can be added
            //to the DI system via service collection

            service.AddScoped<IPathRetriever, AppsettingsRetriever>();

            switch (strategyOption)
            {
                case StrategyOption.UnitTestScripts:
                    service.AddScoped<IAppLogic, AppLogicForCopyingScripts>();
                    break;
                case StrategyOption.WebConfig:
                    service.AddScoped<IAppLogic, AppLogic>();
                    break;
                default:
                    throw new Exception("No strategy chosen");
            }

            
            
            //configuration are heavily used in the .net core DI
            //for configuring services, so can be done usage of that
            var configurationBuilder = new ConfigurationBuilder();
            //adding default configuration file
            configurationBuilder.SetBasePath(GetAppsettingpath()).AddJsonFile("appsettings.json");

            // building the configuration
            var configuration = configurationBuilder.Build();

            //Inject the configuration into the DI system
            //service.AddSingleton<IConfiguration>(configuration);
            service.AddSingleton(configuration);

            // builder service provider
            ServiceProvider = service.BuildServiceProvider();

            
        }

        public string GetAppsettingpath()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");

            var appRootPath = appPathMatcher.Match(path).Value;

            return appRootPath;
        }
    }
}
