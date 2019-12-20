using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MPS.MPSPadraoArquitetura.SharedKernel.Resource;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Web.HtmlHelpers
{
    public static class CampoSeguroHtmlHelper
{
	public static MvcHtmlString CampoSegurodHiddenField(this HtmlHelper htmlHelper, string name, object value)
	{
		var html = new StringBuilder();
		html.Append(htmlHelper.Hidden(name, value));
		html.Append(ObterHashFieldHtml(htmlHelper, name, ObterValorCampo(value)));
		return MvcHtmlString.Create(html.ToString());
	}

	private static string ObterValorCampo(object value)
	{
		return Convert.ToString(value, CultureInfo.CurrentCulture);
	}

	private static MvcHtmlString ObterHashFieldHtml(HtmlHelper htmlHelper, string name, string value)
	{
		return htmlHelper.Hidden((name + "_sha1"), SHA1Helper.GerarHash(value));
	}
}

public static class CampoSeguroValidar
{
	public static void ValidarValor(FormCollection formValues, string name)
	{
		if (formValues != null)
		{
			var valor = formValues.GetValue(name).AttemptedValue;
			var hash = formValues.GetValue(name + "_sha1").AttemptedValue;

			if (hash != SHA1Helper.GerarHash(valor))
			{
				throw new SecurityException(string.Format(MensagensPadrao.MsgCampoSeguro, name));
			}
		}
	}

	public static void ValidarValor(NameValueCollection formValues, string name)
	{
		if (formValues != null)
		{
			var valor = formValues[name];
			var hash = formValues[name + "_sha1"];

			if (hash != SHA1Helper.GerarHash(valor))
			{
				throw new SecurityException(string.Format(MensagensPadrao.MsgCampoSeguro, name));
			}
		}
	}
}
}