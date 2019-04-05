using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCuniversityManagementApp.Startup))]
namespace MVCuniversityManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
