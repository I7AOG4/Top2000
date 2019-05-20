using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Top2000.Startup))]
namespace Top2000
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
