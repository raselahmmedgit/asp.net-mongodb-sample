using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.MongoDBApps.Startup))]
namespace lab.MongoDBApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
