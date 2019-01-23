using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace FileDuplicator
{
    public class DependencyInjection
    {
        IServiceCollection service;

        public DependencyInjection()
        {
            //create a list of dependencies
            service = new ServiceCollection();
        }

        public void Builder()
        {
            //at this point all dependencies can be added
            //to the DI system via service collection


            //configuration are heavily used in the .net core DI
            //for configuring services, so can be done usage of that
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath()


        }
    }
}
