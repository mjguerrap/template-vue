using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Validacoes
{
    public static class ValidacoesDominio
{
	/// <summary>
	/// Método para validar e criar notificações 
	/// </summary>
	/// <param name="validacoes"></param>
	/// <returns></returns>
	public static bool IsValid(params NotificacoesDominio[] validacoes)
	{
		var notificacoesNotNull = validacoes.Where(validation => validation != null);
		var notificacoesDominio = notificacoesNotNull as IList<NotificacoesDominio> ?? notificacoesNotNull.ToList();
		TodasNotificacoes(notificacoesDominio);

		return !notificacoesDominio.Any();
	}

	/// <summary>
	/// Método para Validar uma lista de retornos todos os itens são false retorno true
	/// Não gera notificações
	/// </summary>
	/// <param name="validacoes">params bool[]</param>
	/// <returns>bool</returns>
	public static bool IsValidFalse(params bool[] validacoes)
	{
		var notificacoesDominio = validacoes as IList<bool> ?? validacoes.ToList();

		return !notificacoesDominio.Any(x => x.Equals(true));
	}

	/// <summary>
	/// Método para Validar uma lista de retornos todos os itens são true retorno true
	/// Não gera notificações
	/// </summary>
	/// <param name="validacoes">params bool[]</param>
	/// <returns>bool</returns>
	public static bool IsValidTrue(params bool[] validacoes)
	{
		var notificacoesDominio = validacoes as IList<bool> ?? validacoes.ToList();

		return !notificacoesDominio.Any(x => x.Equals(false));
	}

	/// <summary>
	/// Método para Validar uma lista de retornos se algum item da lista é false retorna true
	/// Não gera notificações
	/// </summary>
	/// <param name="validacoes">params bool[]</param>
	/// <returns>bool</returns>
	public static bool IsValidExistFalse(params bool[] validacoes)
	{
		var notificacoesDominio = validacoes as IList<bool> ?? validacoes.ToList();

		return notificacoesDominio.Any(x => x.Equals(false));
	}

	/// <summary>
	/// Método para Validar uma lista de retornos se algum item da lista é true retorna true
	/// Não gera notificações
	/// </summary>
	/// <param name="validacoes">params bool[]</param>
	/// <returns>bool</returns>
	public static bool IsValidExistTrue(params bool[] validacoes)
	{
		var notificacoesDominio = validacoes as IList<bool> ?? validacoes.ToList();

		return notificacoesDominio.Any(x => x.Equals(true));
	}

	private static void TodasNotificacoes(IEnumerable<NotificacoesDominio> notificacoes)
	{
		notificacoes.ToList().ForEach(validation => { EventoDominio.RaiseEvent(validation); });
	}

	/// <summary>
	/// Valida o tamanho de uma string
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="minimo"></param>
	/// <param name="maximo"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarTamanhoString(string valorString, int minimo, int maximo, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(valorString))
		{
			return null;
		}
		var totalCaracteres = valorString.Trim().Length;
		return (totalCaracteres < minimo || totalCaracteres > maximo) ? new NotificacoesDominio("ValidarTamanhoString", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se a String está vazia ou nula.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarStringVaziaOuNula(string valorString, string mensagem, Type type)
	{
		return (string.IsNullOrEmpty(valorString)) ? new NotificacoesDominio("ValidarStringVaziaOuNula", mensagem, type) : null;
	}

	/// <summary>
	/// Valida a comparação de 2 strings.
	/// </summary>
	/// <param name="string1"></param>
	/// <param name="string2"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarStringsIguais(string string1, string string2, string mensagem, Type type)
	{
		return (!Equals(string1, string2)) ? new NotificacoesDominio("ValidarStringsIguais", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="regex"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarRegexMatch(string valor, string regex, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(valor) && string.IsNullOrEmpty(regex))
		{
			return null;
		}
		return (!Regex.IsMatch(valor, regex, RegexOptions.IgnoreCase)) ? new NotificacoesDominio("ValidarRegexMatch", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se a String possui apenas números
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarStringSomenteNumero(string valorString, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(valorString))
		{
			return null;
		}
		var regex = new Regex(@"^[0-9]+$");
		return (!regex.IsMatch(valorString)) ? new NotificacoesDominio("ValidarStringRegexSomenteNumero", mensagem, type) : null;
	}

	/// <summary>
	/// Valida a string se possui apenas caracteres não numéricos.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarStringSomenteLetras(string valorString, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(valorString))
		{
			return null;
		}
		var regex = new Regex(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$");
		return (!regex.IsMatch(valorString)) ? new NotificacoesDominio("ValidarStringRegexSomenteLetras", mensagem, type) : null;

	}

	/// <summary>
	/// Valida a string se possui apenas caracteres sem espaço e caracteres especiais.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarStringSemEspacoEspeciais(string valorString, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(valorString))
		{
			return null;
		}
		var regex = new Regex(@"[^a-zA-Z0-9_]");
		return (regex.IsMatch(valorString)) ? new NotificacoesDominio("ValidarStringSemEspacoEspeciais", mensagem, type) : null;

	}

	/// <summary>
	/// Valida se a string que foi passada o Telefone possui com mascara (XX) xxxxx-xxxx
	/// </summary>
	/// <param name="telefone"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarTelefoneMascara(string telefone, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(telefone))
		{
			return null;
		}
		//var regex = new Regex(@"^[0-9]{10}$");
		var regex = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");
		return (!regex.IsMatch(telefone)) ? new NotificacoesDominio("ValidarTelefoneRegex", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se a string que foi passada o Telefone sem mascara sem espaco utilizando ddd
	/// </summary>
	/// <param name="telefone"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarTelefone(string telefone, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(telefone))
		{
			return null;
		}
		//var regex = new Regex(@"^[0-9]{10}$");
		var regex = new Regex(@"^[1-9]{2}(?:[2-8]|9[1-9])[0-9]{3}[0-9]{4}$");
		return (!regex.IsMatch(telefone)) ? new NotificacoesDominio("ValidarTelefoneRegex", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o CNPJ possui apenas númeroes e 14 caracteres.
	/// </summary>
	/// <param name="cnpj"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
#pragma warning disable S1541
	public static NotificacoesDominio ValidarCnpj(string cnpj, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(cnpj))
		{
			return null;
		}

		var regex = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})");
		if (regex.IsMatch(cnpj))
		{
			Int32[] digitos, soma, resultado;
			Int32 nrDig;
			String ftmt;
			Boolean[] cnpjOk;
			cnpj = cnpj.Replace("/", "");
			cnpj = cnpj.Replace(".", "");
			cnpj = cnpj.Replace("-", "");

			if (cnpj.Equals("00000000000000") || cnpj.Equals("11111111111111") ||
			 cnpj.Equals("22222222222222") || cnpj.Equals("33333333333333") ||
			 cnpj.Equals("44444444444444") || cnpj.Equals("55555555555555") ||
			 cnpj.Equals("66666666666666") || cnpj.Equals("77777777777777") ||
			 cnpj.Equals("88888888888888") || cnpj.Equals("99999999999999") ||
			(cnpj.Length != 14))
			{
				return new NotificacoesDominio("ValidarCnpjRegex", mensagem, type);
			}
			else
			{
				ftmt = "6543298765432";
				digitos = new Int32[14];
				soma = new Int32[2];
				soma[0] = 0;
				soma[1] = 0;
				resultado = new Int32[2];
				resultado[0] = 0;
				resultado[1] = 0;
				cnpjOk = new Boolean[2];
				cnpjOk[0] = false;
				cnpjOk[1] = false;

				for (nrDig = 0; nrDig < 14; nrDig++)
				{
					digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));
					if (nrDig <= 11)
					{
						soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
					}
					if (nrDig <= 12)
					{
						soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
					}
				}

				for (nrDig = 0; nrDig < 2; nrDig++)
				{
					resultado[nrDig] = (soma[nrDig] % 11);
					if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
					{
						cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);
					}
					else
					{
						cnpjOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
					}

				}

				if (IsValidTrue(cnpjOk[0], cnpjOk[1]))
				{
					return null;
				}
			}
		}
		return new NotificacoesDominio("ValidarCnpjRegex", mensagem, type);
	}
#pragma warning restore S1541


	/// <summary>
	/// Valida se o CPF possui apenas números e 11 caracteres.
	/// </summary>
	/// <param name="cpf"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
#pragma warning disable S1541
	public static NotificacoesDominio ValidarCpf(string cpf, string mensagem, Type type)
	{

		if (string.IsNullOrEmpty(cpf))
		{
			return null;
		}
		var regex = new Regex(@"([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");

		//return (!regex.IsMatch(cpf)) ? new NotificacoesDominio("ValidarCpfRegex", mensagem, type) : null;

		if (regex.IsMatch(cpf))
		{


			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Equals("00000000000") || cpf.Equals("11111111111") ||
			 cpf.Equals("22222222222") || cpf.Equals("33333333333") ||
			 cpf.Equals("44444444444") || cpf.Equals("55555555555") ||
			 cpf.Equals("66666666666") || cpf.Equals("77777777777") ||
			 cpf.Equals("88888888888") || cpf.Equals("99999999999") ||
			(cpf.Length != 11))
			{
				return new NotificacoesDominio("ValidarCpfRegex", mensagem, type);
			}
			else
			{

				tempCpf = cpf.Substring(0, 9);
				soma = 0;

				for (int i = 0; i < 9; i++)
				{
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
				}

				resto = soma % 11;
				if (resto < 2)
				{
					resto = 0;
				}
				else
				{
					resto = 11 - resto;
				}

				digito = resto.ToString();
				tempCpf = tempCpf + digito;
				soma = 0;
				for (int i = 0; i < 10; i++)
				{
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
				}

				resto = soma % 11;
				if (resto < 2)
				{
					resto = 0;
				}
				else
				{
					resto = 11 - resto;
				}

				digito = digito + resto.ToString();
				if (cpf.EndsWith(digito))
				{
					return null;
				}
			}
		}

		return new NotificacoesDominio("ValidarCpfRegex", mensagem, type);
	}
#pragma warning restore S1541

	/// <summary>
	/// Valida se a URL está correta.
	/// </summary>
	/// <param name="url"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarUrl(string url, string mensagem, Type type)
	{
		Uri aux;
		if (!Uri.TryCreate(url, UriKind.Absolute, out aux) || url.Length > 2054)
		{
			return new NotificacoesDominio("ValidaUrlIsValid", mensagem, type);
		}
		return null;
	}

	/// <summary>
	/// Valida se o E-mail passo é válido.
	/// </summary>
	/// <param name="email"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarEmail(string email, string mensagem, Type type)
	{
		if (string.IsNullOrEmpty(email))
		{
			return null;
		}

		var emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
		return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase)) ? new NotificacoesDominio("ValidarEmail", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o Objeto está nulo
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarObjetoNotNull(object obj, string mensagem, Type type)
	{
		return (Equals(obj, null)) ? new NotificacoesDominio("ValidarObjetoNotNull", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o Objeto é diferente de nulo.
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarObjetoIsNull(object obj, string mensagem, Type type)
	{
		return (!Equals(obj, null)) ? new NotificacoesDominio("ValidarObjetoIsNull", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é Menor que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarIntMenorQueEsperado(int valor, int valorEsperado, string mensagem, Type type)
	{
		return (!(valor < valorEsperado)) ? new NotificacoesDominio("ValidarIntMenorQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é maior que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarIntMaiorQueEsperado(int valor, int valorEsperado, string mensagem, Type type)
	{
		return (!(valor > valorEsperado)) ? new NotificacoesDominio("ValidarIntMaiorQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é maior ou igual que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarIntMaiorOuIgualQueEsperado(int valor, int valorEsperado, string mensagem, Type type)
	{
		return (!(valor >= valorEsperado)) ? new NotificacoesDominio("ValidarIntMaiorOuIgualQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é menor ou igual que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarIntMenorOuIgualQueEsperado(int valor, int valorEsperado, string mensagem, Type type)
	{
		return (!(valor <= valorEsperado)) ? new NotificacoesDominio("ValidarIntMaiorOuIgualQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é maior que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarDecimalMaiorQueEsperado(decimal valor, decimal valorEsperado, string mensagem, Type type)
	{
		return (!(valor > valorEsperado)) ? new NotificacoesDominio("ValidarDecimalMaiorQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o valor é maior ou igual que o esperado
	/// </summary>
	/// <param name="valor"></param>
	/// <param name="valorEsperado"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarDecimalMaiorOuIgualQueEsperado(decimal valor, decimal valorEsperado, string mensagem, Type type)
	{
		return (!(valor >= valorEsperado)) ? new NotificacoesDominio("ValidarDecimalMaiorOuIgualQueEsperado", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se a Data é valida.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarData(string data, string mensagem, Type type)
	{
		DateTime dataValida;
		return DateTime.TryParse(data, out dataValida) ? null : new NotificacoesDominio("ValidarData", mensagem, type);
	}

	/// <summary>
	/// Valida se a Data é menor 1753-01-01 12:00:00.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarDataMinima(DateTime? data, string mensagem, Type type)
	{
		DateTime dataValida;
		DateTime dataMinima;
		DateTime.TryParse(data.ToString(), out dataValida);
		DateTime.TryParse("1753-01-01 12:00:00", out dataMinima);
		return (dataValida <= dataMinima) ? new NotificacoesDominio("ValidarDataMinima", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se a Data é menor 1753-01-01 12:00:00.
	/// </summary>
	/// <param name="valorString"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarDataInicioDataFim(DateTime? dataInicio, DateTime? dataFim, string mensagem, Type type)
	{
		bool dataValida = true;
		DateTime dataInicioValida;
		if (dataInicio.HasValue)
		{
			DateTime.TryParse(dataInicio.ToString(), out dataInicioValida);
		}
		else
		{
			dataValida = false;
			dataInicioValida = DateTime.MinValue;
		}

		DateTime dataFimValida;
		if (dataFim.HasValue)
		{
			DateTime.TryParse(dataFim.ToString(), out dataFimValida);
		}
		else
		{
			dataValida = false;
			dataFimValida = DateTime.MaxValue;
		}

		if (!dataValida)
		{
			return new NotificacoesDominio("ValidarDataInicioDataFim", mensagem + " Data Invalida", type);
		}
		if ((dataInicioValida.Equals(DateTime.MinValue) || dataInicioValida.Equals(DateTime.MaxValue) || dataFimValida.Date.Equals(DateTime.MinValue.Date) || dataFimValida.Date.Equals(DateTime.MaxValue.Date)))
		{
			return new NotificacoesDominio("ValidarDataInicioDataFim", mensagem + " Datas Nulas", type);
		}

		int result = DateTime.Compare(dataInicioValida, dataFimValida);
		return (result > -1) ? new NotificacoesDominio("ValidarDataInicioDataFim", mensagem, type) : null;
	}

	/// <summary>
	/// Valida se o GUID está vazio.
	/// </summary>
	/// <param name="valorGUID"></param>
	/// <param name="mensagem"></param>
	/// <returns></returns>
	public static NotificacoesDominio ValidarGuiDVazio(Guid valorGUID, string mensagem, Type type)
	{
		return (valorGUID == Guid.Empty) ? new NotificacoesDominio("ValidarGUIDVazio", mensagem, type) : null;
	}
}
}
