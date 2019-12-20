using Elmah;
using MPS.SSO.CustomClaims;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Base;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Web.HtmlHelpers
{
    public static class FuncionarioHtmlHelper
{
	public static MvcHtmlString ObterFotoFuncionario(this HtmlHelper htmlHelper, string urlWebSite)
	{
		var html = new StringBuilder();
		int matricula = ClaimsHelper.ObterClaim(Claims.Matricula).Value.ToInt();
		string primeiroNome = ClaimsHelper.ObterClaim(Claims.PrimeiroNome).Value;

		byte[] foto = null;

		var appFuncionario = SimpleInjectorInitializerFactory.GetInstance<IFotoFuncionarioApp>();
		try
		{
			foto = appFuncionario.ObterFotoFuncionario(matricula);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
		}

		html.AppendLine("<span href=\"#\">" + primeiroNome + "</span>");

		if (foto != null)
		{
			html.AppendLine("<img id='imgFotoServidor' src='data:image/png; base64," + Convert.ToBase64String(foto) + "' class='rounded-circle user-image' alt='Foto' />");
		}
		else
		{
			html.AppendLine("<img id='imgFotoServidor' src='" + urlWebSite + "Content/Images/PersonPlaceholder.png' class='rounded-circle user-image' alt='Foto' />");
		}

		html.AppendLine("<input type='hidden' value='" + matricula + "' id='hdnIdentificaUsuario' />");

		return MvcHtmlString.Create(html.ToString());
	}

	public static MvcHtmlString ObterCargoFuncionario(this HtmlHelper htmlHelper)
	{
		var html = new StringBuilder();
		int matricula = ClaimsHelper.ObterClaim(Claims.Matricula).Value.ToInt();

		string cargo = string.Empty;

		try
		{
			cargo = "CARGO: Definir a implementação do cargo conforme a regra do sistema";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
		}

		if (!string.IsNullOrEmpty(cargo))
		{
			html.AppendLine(cargo);
		}

		return MvcHtmlString.Create(html.ToString());
	}

	public static MvcHtmlString ObterUnidadeFuncionario(this HtmlHelper htmlHelper)
	{
		var html = new StringBuilder();
		int matricula = ClaimsHelper.ObterClaim(Claims.Matricula).Value.ToInt();

		string unidade = string.Empty;

		try
		{
			unidade = "Definir a implementação da unidade conforme a regra do sistema";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
		}

		if (!string.IsNullOrEmpty(unidade))
		{
			html.AppendLine(unidade);
		}

		return MvcHtmlString.Create(html.ToString());
	}

}
}