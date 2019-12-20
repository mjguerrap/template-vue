using System;
using System.Security.Cryptography;
using System.Text;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class Criptografia
{
	/*
         Exemplo ChaveCriptografiaId 

         3 = MPS
         11 = Arquitetura
         9 = Sistemas
         12 = MPSPadraoArquitetura
    */

	private const int ChaveCriptografiaId = 311912;

	private static byte[] RetornaHash(string texto)
	{
		using (MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider())
		{
			return hashProvider.ComputeHash(Encoding.UTF8.GetBytes(texto));
		}
	}

	private static TripleDESCryptoServiceProvider RetornaTdes(string key)
	{
		TripleDESCryptoServiceProvider algoritmoTDES = new TripleDESCryptoServiceProvider
		{
			Key = RetornaHash(key),
			Mode = CipherMode.ECB,
			Padding = PaddingMode.PKCS7
		};
		return algoritmoTDES;
	}

	public static string Criptografar(string key, string texto)
	{
		byte[] resultado;
		UTF8Encoding utf8 = new UTF8Encoding();

		using (TripleDESCryptoServiceProvider algoritmoTDES = RetornaTdes(key))
		{

			byte[] dadoParaCriptografar = utf8.GetBytes(texto);
			using (ICryptoTransform encriptacao = algoritmoTDES.CreateEncryptor())
			{
				resultado = encriptacao.TransformFinalBlock(dadoParaCriptografar, 0, dadoParaCriptografar.Length);
			}
		}

		return Convert.ToBase64String(resultado);

	}

	public static string Decriptografar(string key, string texto)
	{
		byte[] resultado;
		UTF8Encoding utf8 = new UTF8Encoding();

		using (TripleDESCryptoServiceProvider algoritmoTDES = RetornaTdes(key))
		{
			try
			{
				byte[] dadoParaDecriptografar = Convert.FromBase64String(texto);
				using (ICryptoTransform decriptacao = algoritmoTDES.CreateDecryptor())
				{
					resultado = decriptacao.TransformFinalBlock(dadoParaDecriptografar, 0, dadoParaDecriptografar.Length);
				}
			}
			catch (FormatException e)
			{
				ValidacoesDominio.IsValid(new NotificacoesDominio("CriptografiaDecriptografar", e.Message, e.GetType(), true));
				return texto;
			}
			catch (CryptographicException e)
			{
				ValidacoesDominio.IsValid(new NotificacoesDominio("CriptografiaDecriptografar", e.Message, e.GetType(), true));
				return texto;
			}
		}

		return utf8.GetString(resultado);
	}

	public static int CriptografarIdsParaUrl(int id)
	{
		string valorBinario = Convert.ToString(id, 2);
		valorBinario = valorBinario.Insert(0, "000000000000000000000000000000".Substring(0, 30 - valorBinario.Length));
		valorBinario = InverterTexto(valorBinario);

		int idInvertido = Convert.ToInt32(valorBinario, 2);

		return idInvertido + ChaveCriptografiaId;
	}

	public static int DescriptografarIdsParaUrl(int idCriptografado)
	{
		int idInvertido = idCriptografado - ChaveCriptografiaId;
		string valorBinario = Convert.ToString(idInvertido, 2);
		try
		{
			valorBinario = valorBinario.Insert(0, "000000000000000000000000000000".Substring(0, 30 - valorBinario.Length));
		}
		catch (ArgumentOutOfRangeException e)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("CriptografiaDescriptografarIdsParaURL", e.Message, e.GetType(), true));
			return idCriptografado;
		}

		valorBinario = InverterTexto(valorBinario);

		int id = Convert.ToInt32(valorBinario, 2);
		return id;
	}

	public static long CriptografarIdsParaUrl(long id)
	{
		string valorBinario = Convert.ToString(id, 2);
		valorBinario = valorBinario.Insert(0, "000000000000000000000000000000".Substring(0, 30 - valorBinario.Length));
		valorBinario = InverterTexto(valorBinario);

		long idInvertido = Convert.ToInt64(valorBinario, 2);

		return idInvertido + ChaveCriptografiaId;
	}

	public static long DescriptografarIdsParaUrl(long idCriptografado)
	{
		long idInvertido = idCriptografado - ChaveCriptografiaId;
		string valorBinario = Convert.ToString(idInvertido, 2);
		try
		{
			valorBinario = valorBinario.Insert(0, "000000000000000000000000000000".Substring(0, 30 - valorBinario.Length));
		}
		catch (ArgumentOutOfRangeException e)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("CriptografiaDescriptografarIdsParaURL", e.Message, e.GetType(), true));
			return idCriptografado;
		}

		valorBinario = InverterTexto(valorBinario);

		long id = Convert.ToInt64(valorBinario, 2);
		return id;
	}

	private static string InverterTexto(string entrada)
	{
		char[] saida = entrada.ToCharArray();
		Array.Reverse(saida);
		return new string(saida);
	}
}
}
