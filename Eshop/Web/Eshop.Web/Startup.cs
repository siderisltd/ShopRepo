﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eshop.Web.Startup))]
namespace Eshop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}