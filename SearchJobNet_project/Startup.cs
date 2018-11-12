using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchJobNet_project.Startup))]
namespace SearchJobNet_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
