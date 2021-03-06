﻿using Ignobilis.Business.Initializers;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Ignobilis.Business.Initializers
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            var sqlConnectionString = IgnobilisService.Instance.Settings.ConnectionString;
            GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            app.MapSignalR();
            

            GlobalConfiguration.Configure(config =>
                                          {
                                              config.MapHttpAttributeRoutes();
                                          });
        }
    }
}