using System;
using System.Collections.Generic;
using System.Linq;
using Convocation.DAL;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Convocation.Startup))]

namespace Convocation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
