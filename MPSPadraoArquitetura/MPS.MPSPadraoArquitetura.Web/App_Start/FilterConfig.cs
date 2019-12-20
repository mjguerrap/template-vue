using System.Web.Mvc;
using MPS.MPSPadraoArquitetura.Web.Filters;

namespace MPS.MPSPadraoArquitetura.Web
{
    public static class FilterConfig
{
	public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	{
		filters.Add(new HandleErrorAttribute());
		filters.Add(new AutorizacaoCustomAttribute());
	}
}
}
