using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Validacoes.Pesquisa
{
    public static class PesquisaValidacao
{
	/// <summary>
	/// Validar Datas Inicio e Fim verificando intervalo de datas
	/// </summary>
	/// <param name="basePesquisa">BasePesquisa</param>
	/// <returns>bool</returns>
	public static bool ValidarDatas(BasePesquisa basePesquisa)
	{
		return
			ValidacoesDominio.IsValid(
		#region Datas
					ValidacoesDominio.ValidarDataInicioDataFim(basePesquisa.DataInicio, basePesquisa.DataFim, "Intervalo de Datas invalido", basePesquisa.GetType())
		#endregion Datas
					);
	}

	/// <summary>
	/// Validar Data Fim que não seja menor que 01/01/1753
	/// </summary>
	/// <param name="basePesquisa">BasePesquisa</param>
	/// <returns>bool</returns>
	public static bool ValidarDataFim(BasePesquisa basePesquisa)
	{
		return
		   ValidacoesDominio.IsValid(
		#region Datas
				   ValidacoesDominio.ValidarDataMinima(basePesquisa.DataFim, "Data Fim da Pesquisa Não pode inferior 01/01/1753.", basePesquisa.GetType())
		#endregion Datas
					);
	}

	/// <summary>
	/// Validar Data Inicio que não seja menor que 01/01/1753
	/// </summary>
	/// <param name="basePesquisa">BasePesquisa</param>
	/// <returns>bool</returns>
	public static bool ValidarDataInicio(BasePesquisa basePesquisa)
	{
		return
		   ValidacoesDominio.IsValid(
		#region Datas
				   ValidacoesDominio.ValidarDataMinima(basePesquisa.DataInicio, "Data Início da Pesquisa Não pode inferior 01/01/1753.", basePesquisa.GetType())
		#endregion Datas
					);
	}
}
}
