using System;
using MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;

namespace MPS.MPSPadraoArquitetura.WCF
{
    public class Global : System.Web.HttpApplication
{

	protected void Application_Start(object sender, EventArgs e)
	{
		AutoMapperConfig.RegisterMappings();
		SimpleInjectorWcfInitializer.Initialize();
	}
}
}