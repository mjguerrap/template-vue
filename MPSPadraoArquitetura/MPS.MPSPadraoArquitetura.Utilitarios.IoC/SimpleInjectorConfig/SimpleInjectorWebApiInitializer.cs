using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.Containers;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig
{
    public static class SimpleInjectorWebApiInitializer
{
	public static void Initialize(HttpConfiguration config)
	{
		Container container = new Container();

		container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

		InitializeContainer(container);

		container.RegisterWebApiControllers(config);

		config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		EventoDominio.Container = new ContainerAPI(config.DependencyResolver);

		container.Verify();
	}

	private static void InitializeContainer(Container container)
	{
		BootStrapper.RegisterServices(container);
	}
}
}
