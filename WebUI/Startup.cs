using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.Startup))]

namespace WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  ConfigureAuth(app);
        }
    }

}
