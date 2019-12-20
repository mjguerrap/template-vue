using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.Containers;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig
{
    public static class SimpleInjectorWcfInitializer
{
	public static void Initialize()
	{
		Container container = new Container();

		container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

		InitializeContainer(container);

		SimpleInjectorServiceHostFactory.SetContainer(container);

		EventoDominio.Container = new ContainerWCF(container);

		container.Verify();
	}

	private static void InitializeContainer(Container container)
	{
		BootStrapper.RegisterServices(container);
	}
}
}
