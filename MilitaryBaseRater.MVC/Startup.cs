using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilitaryBaseRater.MVC.Startup))]
namespace MilitaryBaseRater.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
