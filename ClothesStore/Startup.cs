using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothesStore.Startup))]
namespace ClothesStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
