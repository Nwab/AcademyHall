using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademyHall.Startup))]
namespace AcademyHall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
