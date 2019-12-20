using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.Containers;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig
{
    public static class SimpleInjectorMvcInitializer
{
	public static void Initialize()
	{
		var container = new Container();
		container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

		InitializeContainer(container);

		container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

		var injector = new SimpleInjectorDependencyResolver(container);

		DependencyResolver.SetResolver(injector);
		EventoDominio.Container = new ContainerMVC(injector);

		container.Verify();

		SimpleInjectorInitializerFactory.SetContainer(container);
	}

	private static void InitializeContainer(Container container)
	{
		BootStrapper.RegisterServices(container);
	}
}

public static class SimpleInjectorInitializerFactory
{
	private static Container _container;

	public static void SetContainer(Container container)
	{
		_container = container;
	}

	public static T GetInstance<T>() where T : class
	{
		return _container.GetInstance<T>();
	}
}
}
