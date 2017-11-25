using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MMM.Presentation.Startup))]

namespace MMM.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}