using System;
using System.Text;
using System.Security.Cryptography;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class SHA1Helper
{
	public static void CodificarParaSha1(System.Web.UI.Page pagina, System.Web.UI.Control controleParaCodificar)
	{
		System.Web.UI.ClientScriptManager csm = pagina.ClientScript;

		if (!csm.IsClientScriptIncludeRegistered("includeSHA1"))
		{
			csm.RegisterClientScriptInclude(typeof(String), "includeSHA1", "Scripts/sha1.js");
		}

		if (!csm.IsClientScriptBlockRegistered(typeof(String), "scriptParaCodificar"))
		{
			StringBuilder script = new StringBuilder();

			// frase de seguranca
			script.Append("function CodificarParaSHA1(controlId){");
			script.Append("var xsha1 = ");
			script.Append("document.getElementById(controlId);");
			script.Append("if(xsha1 != null && xsha1.value != null && xsha1.value != '' )");
			script.Append("xsha1.value = hex_sha1(xsha1.value);");
			script.Append("}");

			csm.RegisterClientScriptBlock(typeof(String), "scriptParaCodificar", script.ToString(), true);
		}

		String idDoCliente = controleParaCodificar.ClientID;

		if (csm.IsOnSubmitStatementRegistered(typeof(String), "keyCodificar" + idDoCliente))
		{
			return;
		}


		// Codifica controle para SHA1
		StringBuilder scriptControle = new StringBuilder();
		scriptControle.Append("CodificarParaSHA1('");
		scriptControle.Append(idDoCliente);
		scriptControle.Append("');");

		csm.RegisterOnSubmitStatement(typeof(String), "keyCodificar" + idDoCliente, scriptControle.ToString());
	}

	public static string Sha1String(string text)
	{
		ASCIIEncoding encoding = new ASCIIEncoding();
		StringBuilder shaBuilder = new StringBuilder();
		using (SHA1 sha = SHA1.Create())
		{
			byte[] buffer = encoding.GetBytes(text);
			byte[] hash = sha.ComputeHash(buffer);
			foreach (byte item in hash)
			{
				shaBuilder.Append(item.ToString("x2"));
			}
		}
		return (shaBuilder.ToString());
	}

	public static string GerarHash(string texto)
	{
		var encoding = new ASCIIEncoding();
		var shaBuilder = new StringBuilder();

		using (SHA1 sha = SHA1.Create())
		{
			byte[] buffer = encoding.GetBytes(texto);
			byte[] hash = sha.ComputeHash(buffer);
			foreach (byte item in hash)
			{
				shaBuilder.Append(item.ToString("x2"));
			}
		}

		return shaBuilder.ToString();
	}

}
}
