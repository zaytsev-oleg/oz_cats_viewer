using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReturnOnIntelligence.Startup))]
namespace ReturnOnIntelligence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
