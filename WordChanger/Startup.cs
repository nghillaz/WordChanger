using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordChanger.Startup))]
namespace WordChanger
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
