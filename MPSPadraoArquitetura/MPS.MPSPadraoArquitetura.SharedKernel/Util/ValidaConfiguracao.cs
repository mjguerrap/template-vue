using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.ServiceModel;
using System.Text;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
	public class ValidaConfiguracao : IValidaConfiguracao
{
	#region Configuração

	protected string Ambiente { get; set; }

	protected string Host
	{
		get
		{
			string resultado;

			switch (RecupraAmbiente())
			{
				#region RHF
				case "tst01.tj.sp.intranet":
				case "dtcvtrhf-01.tj.sp.intranet":
					resultado = "tst01.tjsp.jus.br";
					break;
				case "dtcvdrhf-01.tj.sp.intranet":
				case "dtcvdrhf-02.tj.sp.intranet":
				case "dtcvdrhf-01":
				case "dtcvdrhf-02":
				case "dev.tjsp.jus.br":
				case "dev":
					resultado = "dev.tjsp.jus.br";
					break;
				case "dtcvqrhf-01.tj.sp.intranet":
				case "dtcvqrhf-02.tj.sp.intranet":
				case "dtcvqrhf-01":
				case "dtcvqrhf-02":
				case "qa.tjsp.jus.br":
				case "qa":
					resultado = "qa.tjsp.jus.br";
					break;
				case "dtcvurhf-01.tj.sp.intranet":
				case "dtcvurhf-02.tj.sp.intranet":
				case "dtcvurhf-01":
				case "dtcvurhf-02":
				case "uat.tjsp.jus.br":
				case "uat":
					resultado = "uat.tjsp.jus.br";
					break;
				case "dtcvhrhf-01.tj.sp.intranet":
				case "dtcvhrhf-02.tj.sp.intranet":
				case "dtcvhrhf-01":
				case "dtcvhrhf-02":
				case "hom.tjsp.jus.br":
				case "hom":
					resultado = "hom.tjsp.jus.br";
					break;
				#region Prod Compatilhado

				case "dtcvprhf-01.tj.sp.intranet":
				case "dtcvprhf-02.tj.sp.intranet":
				case "dtcvprhf-03.tj.sp.intranet":
				case "dtcvprhf-04.tj.sp.intranet":
				case "dtcvprhf-05.tj.sp.intranet":
				case "dtcvprhf-06.tj.sp.intranet":
				case "dtcvprhf-01":
				case "dtcvprhf-02":
				case "dtcvprhf-03":
				case "dtcvprhf-04":
				case "dtcvprhf-05":
				case "dtcvprhf-06":
				case "prod.tjsp.jus.br":
				case "www.tjsp.jus.br":
				case "prod":

					resultado = "www.tjsp.jus.br";
					break;
				#endregion Prod Compatilhado

				#region Prod Holos
				case "dtcvpholos-01.tj.sp.intranet":
				case "dtcvpholos-02.tj.sp.intranet":
				case "dtcvpholos-03.tj.sp.intranet":
				case "dtcvpholos-04.tj.sp.intranet":
				case "dtcvpholos-05.tj.sp.intranet":
				case "dtcvpholos-06.tj.sp.intranet":
				case "dtcvpholos-01":
				case "dtcvpholos-02":
				case "dtcvpholos-03":
				case "dtcvpholos-04":
				case "dtcvpholos-05":
				case "dtcvpholos-06":

					resultado = "www.tjsp.jus.br";
					break;
				#endregion Prod Holos

				#region Prod Frequencia
				case "dtcvpfreq-01.tj.sp.intranet":
				case "dtcvpfreq-02.tj.sp.intranet":
				case "dtcvpfreq-03.tj.sp.intranet":
				case "dtcvpfreq-01":
				case "dtcvpfreq-02":
				case "dtcvpfreq-03":

					resultado = "www.tjsp.jus.br";
					break;
				#endregion Prod Frequencia

				#region Prod Subtituição
				case "dtcvpsubs-01.tj.sp.intranet":
				case "dtcvpsubs-02.tj.sp.intranet":
				case "dtcvpsubs-03.tj.sp.intranet":
				case "dtcvpsubs-01":
				case "dtcvpsubs-02":
				case "dtcvpsubs-03":

					resultado = "www.tjsp.jus.br";
					break;
				#endregion Prod Subtituição
				#endregion RHF

				#region RHM

				case "tstrhm01.tj.sp.intranet":
				case "tstrhm01.tjsp.jus.br":
				case "dtcvtrhm-01.tj.sp.intranet":
					resultado = "tstrhm01.tjsp.jus.br";
					break;
				case "dtcvdrhm-01.tj.sp.intranet":
				case "dtcvdrhm-01":
					resultado = "dev.tjsp.jus.br/RHM";
					break;
				case "dtcvqrhm-01.tj.sp.intranet":
				case "dtcvqrhm-02.tj.sp.intranet":
				case "dtcvqrhm-01":
				case "dtcvqrhm-02":
					resultado = "qa.tjsp.jus.br/RHM";
					break;
				case "dtcvurhm-01.tj.sp.intranet":
				case "dtcvurhm-02.tj.sp.intranet":
				case "dtcvurhm-01":
				case "dtcvurhm-02":
					resultado = "uat.tjsp.jus.br/RHM";
					break;
				case "dtcvhrhm-01.tj.sp.intranet":
				case "dtcvhrhm-02.tj.sp.intranet":
				case "dtcvhrhm-03.tj.sp.intranet":
				case "dtcvhrhm-01":
				case "dtcvhrhm-02":
				case "dtcvhrhm-03":
					resultado = "hom.tjsp.jus.br/RHM";
					break;

				case "dtcvprhm-01.tj.sp.intranet":
				case "dtcvprhm-02.tj.sp.intranet":
				case "dtcvprhm-03.tj.sp.intranet":
				case "dtcvprhm-01":
				case "dtcvprhm-02":
				case "dtcvprhm-03":
					resultado = "www.tjsp.jus.br/RHM";
					break;
				#endregion RHM

				default:
					resultado = "localhost";
					break;

			}
			return resultado;
		}
	}

	private string RecupraAmbiente()
	{
		if (!string.IsNullOrEmpty(Ambiente))
		{
			return Ambiente.ToLower();
		}
		else
		{
			if (!Equals(OperationContext.Current, null))
			{
				return OperationContext.Current.IncomingMessageHeaders.To.Host;
			}			
		}
		return null;
	}

	protected string ConnectionString
	{
		get
		{
			string resultado = "";
			switch (Host)
			{
				case "localhost":
					resultado = @"DTCVTRHF-DB01\IT01A";
					///Quando Sistemas forem da SEMA trocar a validação de LocalHost
					//resultado = @"DTCVTRHM-DB01\IT01A";
					break;
				#region RHF
				case "tst01.tjsp.jus.br":
				case "tst02.tjsp.jus.br":
				case "tst03.tjsp.jus.br":
				case "tst04.tjsp.jus.br":
					resultado = @"DTCVTRHF-DB01\IT01A";
					break;
				case "dev.tjsp.jus.br":
					resultado = @"DTCVDRHF-DB01\IDEV01A";
					break;
				case "qa.tjsp.jus.br":
					resultado = @"DTCVQRHF-DB01\IQA01A";
					break;
				case "uat.tjsp.jus.br":
					resultado = @"DTCVURHF-DB01\IUAT01A";
					break;
				case "hom.tjsp.jus.br":
					resultado = @"DTCVHRHF-DB01\IHML01A";
					break;
				case "www.tjsp.jus.br":
					resultado = @"DTCSRH-SQL01\IPRD01A";
					break;
				#endregion RHF

				#region RHM
				case "tstrhm01.tjsp.jus.br":
					resultado = @"DTCVTRHF-DB01\IT01A";
					break;
				case "dev.tjsp.jus.br/RHM":
					resultado = @"DTCVDRHM-DB01\IDEV01A";
					break;
				case "qa.tjsp.jus.br/RHM":
					resultado = @"DTCVQRHM-DB01\IQA01A";
					break;
				case "uat.tjsp.jus.br/RHM":
					resultado = @"DTCVURHF-DB01\IUAT01A";
					break;
				case "hom.tjsp.jus.br/RHM":
					resultado = @"DTCVHRHM-DB01\IHML01A";
					break;
				case "www.tjsp.jus.br/RHM":
					resultado = @"DTCRHMSQL01\IPRD01A";
					break;
				#endregion RHM
				default:
					resultado = @"";
					break;

			}
			return resultado;
		}
	}

	protected static IEnumerable<string> ChaveBanco
	{
		get
		{
			var listChaveBanco = MemoryCache.Default.Get("ChaveBanco") as List<string>;
			if (Equals(listChaveBanco, null) || !listChaveBanco.Any())
			{
				var chaveBanco = ConfigurationManager.AppSettings["ChaveBanco"];
				if (string.IsNullOrEmpty(chaveBanco))
				{
					listChaveBanco = new List<string>();
				}
				else
				{
					listChaveBanco = chaveBanco.Replace(" ", "").Split(',').ToList();
						MemoryCache.Default.Add("ChaveBanco", listChaveBanco, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) });
				}

			}
			return listChaveBanco;
		}
	}

	protected class ObjConfig
	{
		public ObjConfig(string chave, string valor, int statusChave)
		{
			Chave = chave;
			Valor = valor;
			StatusChave = statusChave;
		}

		public string Chave { get; set; }

		public string Valor { get; set; }

		/// <summary>
		/// 0 - Variavel não tratada
		/// 1 - Valor OK
		/// 2 - Valor Errado
		/// </summary>
		public int StatusChave { get; set; }
	}

	/// <summary>
	/// Método para validar se a chave passada é do tipo Connection String 
	/// </summary>
	/// <param name="chave"></param>
	/// <param name="valor"></param>
	/// <returns>ObjConfig populado com as propriedades populadas</returns>
	protected ObjConfig VerificaStringConection(string chave, string valor)
	{
		int retorno = 2;
		if (valor.ToLower().Contains("server") || valor.ToLower().Contains("data source") && !chave.ToLower().Contains("mps.seguranca.dados.usuarios"))
		{
			if (valor.ToLower().Contains(ConnectionString.ToLower()))
			{
				retorno = 1;
			}

			if (chave.ToLower().Contains("mps.seguranca.dados.usuarios") && valor.ToLower().Contains("mps.seguranca.dados.sqlserver.usuariosdados,mps.seguranca.dados.sqlserver"))
			{
				retorno = 1;
			}
		}
		else
		{
			retorno = 0;
		}

		return new ObjConfig(chave, valor, retorno);
	}

	#endregion Configuração

	/// <summary>
	/// Método que retorna a versão com sistema recuperando dados da DDL
	/// Obs.: A versão informada sempre será da DLL MPS.{Aplicação}.SharedKernel
	/// </summary>
	///  /// <returns>Objeto de Retorno Prop 
	/// - Resultado Bool: informa o status da verificação 
	/// - RetornoMensagem string: Exibe a mengem do problema encontrado </returns>
	public BaseRetorno VersaoSistema()
	{
		System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
		FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
		string version = fvi.FileVersion;

		return new BaseRetorno(true, $"Versão - {version}");
	}


	/// <summary>
	/// Método para validar se o ambiente atual ou informando esta correto com as configurações de conexão
	/// </summary>
	/// <param name="ambiente">Opcional - quando não informando recupera o host do servidor</param>
	/// <returns>Objeto de Retorno Prop 
	/// - Resultado Bool: informa o status da verificação 
	/// - RetornoMensagem string: Exibe a mengem do problema encontrado </returns>
	public BaseRetorno ValidarConection(string ambiente)
	{
		Ambiente = ambiente;
		ObjConfig infoConfig;
		StringBuilder msg = new StringBuilder();
		bool retorno = true;
		var sAllConectionStrings = ConfigurationManager.ConnectionStrings;
		if (!ChaveBanco.Any())
		{
			return new BaseRetorno(false, $"Chave de Banco não definida nas configurações no ambiente {Host}");
		}

		for (int i = 0; i < sAllConectionStrings.Count; i++)
		{

			infoConfig = (VerificaStringConection(sAllConectionStrings[i].Name, sAllConectionStrings[i].ConnectionString));
			if (ValidacoesDominio.IsValidTrue(ChaveBanco.Contains(infoConfig.Chave), infoConfig.StatusChave.Equals(2)))
			{
				msg.AppendLine($"Conexão {infoConfig.Chave} errada para o ambiente {Host}");
				retorno = false;
			}
		}

		return new BaseRetorno(retorno, msg.ToString());
	}

}
}
