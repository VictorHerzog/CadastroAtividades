using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadastroDeAtividades.Startup))]
namespace CadastroDeAtividades
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
