using Owin;
using Microsoft.Owin;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;
using MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers;

[assembly: OwinStartup(typeof(MPS.MPSPadraoArquitetura.Web.Startup))]
namespace MPS.MPSPadraoArquitetura.Web
{
    public partial class Startup
{
	public void Configuration(IAppBuilder app)
	{
		SimpleInjectorMvcInitializer.Initialize();
		ConfigureAuth(app);
	}
}
}
