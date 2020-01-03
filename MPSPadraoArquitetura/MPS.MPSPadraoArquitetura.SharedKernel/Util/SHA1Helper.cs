using System;
using System.Text;
using System.Security.Cryptography;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class SHA1Helper { 

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
