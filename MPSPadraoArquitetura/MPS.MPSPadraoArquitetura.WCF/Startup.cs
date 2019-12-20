using System;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;
using MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers;

namespace MPS.MPSPadraoArquitetura.WCF
{
    public class Startup
{
	protected void Application_Start(object sender, EventArgs e)
	{
		using (var container = new Container())
		{
			AutoMapperConfig.RegisterMappings();
			container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();
			SimpleInjectorServiceHostFactory.SetContainer(container);
			SimpleInjectorWcfInitializer.Initialize();
		}
	}

}
}