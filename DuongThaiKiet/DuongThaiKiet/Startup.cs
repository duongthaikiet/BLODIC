using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuongThaiKiet.Startup))]
namespace DuongThaiKiet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
