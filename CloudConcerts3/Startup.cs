using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudConcerts3.Startup))]
namespace CloudConcerts3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
