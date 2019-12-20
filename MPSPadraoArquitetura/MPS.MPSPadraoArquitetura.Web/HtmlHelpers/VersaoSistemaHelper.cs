using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace MPS.MPSPadraoArquitetura.Web.HtmlHelpers
{
    public static class VersaoSistemaHelper
{
	public static string VersaoSistema()
	{
		var versao = SimpleInjectorInitializerFactory.GetInstance<IValidaConfiguracao>().VersaoSistema();

		string release = ConfigurationManager.AppSettings["Release"];

		if (!string.IsNullOrEmpty(release))
		{
			release = release.Split('-')[1];
		}

		return $"{versao.RetornoMensagem}.{release}";
	}
}
}