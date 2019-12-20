using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;
using MPS.SSO.CustomClaims;

namespace MPS.MPSPadraoArquitetura.Web.Filters
{
    [AttributeUsage(AttributeTargets.All)]
public class AutorizacaoCustomAttribute : AuthorizeAttribute
{
	protected override bool AuthorizeCore(HttpContextBase httpContext)
	{
		if (!HttpContext.Current.User.Identity.IsAuthenticated)
		{
			return false;
		}

		if (!ValidaAmbiente(httpContext))
		{
			return false;
		}

		var isAuthorized = base.AuthorizeCore(httpContext);

		if (!isAuthorized)
		{
			string usuario = ClaimsHelper.ObterClaim(Claims.Matricula).Value;
			Exception exception = new HttpException(401, $"Usuário {HttpContext.Current.User.Identity.Name} - {usuario} não autorizado para acessar a página: {HttpContext.Current.Request.Url.AbsoluteUri}");
			ErrorSignal.FromCurrentContext().Raise(exception, HttpContext.Current);
		}



		return isAuthorized;
	}

	protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
	{
		if (filterContext != null && filterContext.HttpContext.Request.IsAuthenticated && filterContext.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
		{
			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "ConteudoEstatico", action = "PaginaNaoAutorizada", area = "" }));
		}
		else
		{
			base.HandleUnauthorizedRequest(filterContext);
		}
	}

	/// <summary>
	/// Método para validar a connection do ambiente esta correta.
	/// </summary>
	/// <param name="httpContext"></param>
	/// <returns></returns>
	protected static bool ValidaAmbiente(HttpContextBase httpContext)
	{
		var ambiente = SimpleInjectorInitializerFactory.GetInstance<IValidaConfiguracao>().ValidarConection(httpContext.Request.Url.Host);

		if (httpContext != null && !ambiente.Resultado)
		{
			Exception exception = new InvalidOperationException($"Erro de Configuração de Ambiente - {ambiente.RetornoMensagem}");
			ErrorSignal.FromCurrentContext().Raise(exception, HttpContext.Current);
			return false;
		}
		return true;
	}
}
}