using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Validacoes.Pesquisa;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa
{
    public class BasePesquisa : ParametrosDataTables
{
	public byte StatusRegistroId { get; set; }
	public string Descricao { get; set; }
	public int? Matricula { get; set; }
	public string NomeFuncionario { get; set; }
	public DateTime? DataInicio { get; set; }
	public DateTime? DataFim { get; set; }

	/// <summary>
	/// Método para verificar se o intervalo de datas
	/// </summary>
	/// <returns></returns>
	public virtual bool ValidarDatas()
	{
		if (ValidarDataInicio() && ValidarDataFim())
		{
			return PesquisaValidacao.ValidarDatas(this);
		}
		return false;
	}

	/// <summary>
	/// Método para verificar data inicio
	/// </summary>
	/// <returns></returns>
	public virtual bool ValidarDataInicio()
	{
		return PesquisaValidacao.ValidarDataInicio(this);
	}

	/// <summary>
	/// Método para verificar data inicio
	/// </summary>
	/// <returns></returns>
	public virtual bool ValidarDataFim()
	{
		return PesquisaValidacao.ValidarDataFim(this);
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem para Expressao de pesquisa Por Matrícula 
	/// </summary>
	/// <returns></returns>
	public Expression<Func<BasePesquisa, bool>> PorMatricula()
	{
		Expression<Func<BasePesquisa, bool>> expression = x => x.Matricula == Matricula;
		return expression;
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem para Expressao de pesquisa por Nome Funcionário
	/// </summary>
	/// <returns></returns>
	public Expression<Func<BasePesquisa, bool>> PorNomeFuncionario()
	{
		Expression<Func<BasePesquisa, bool>> expression = x => x.NomeFuncionario == NomeFuncionario;
		return expression;
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem de Expressao de pesquisa por Periodo de Cadastro
	/// </summary>
	/// <returns></returns>
	public Expression<Func<BaseUsuarioCadastro, bool>> PorPeriodoCadastro()
	{
		Expression<Func<BaseUsuarioCadastro, bool>> expression = null;

		if (ValidarDatas())
		{
			expression = x => (x.DataCadastro >= DataInicio && x.DataCadastro <= DataFim);
		}
		else if (ValidarDataInicio())
		{
			expression = x => (x.DataCadastro >= DataInicio);
		}
		else if (ValidarDataFim())
		{
			DataFim = DataFim.ToDateTimeDataFim();
			expression = x => (x.DataCadastro <= DataFim);
		}
		else
		{
			return expression;
		}

		return expression;
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem de Expressao de pesquisa por Periodo de Cadastro
	/// </summary>
	/// <returns></returns>
	public Expression<Func<BaseUsuarioAlteracao, bool>> PorPeriodoAlteracao()
	{
		Expression<Func<BaseUsuarioAlteracao, bool>> expression = null;

		if (ValidarDatas())
		{
			expression = x => (x.DataAlteracao >= DataInicio && x.DataAlteracao <= DataFim);
		}
		else if (ValidarDataInicio())
		{
			expression = x => (x.DataAlteracao >= DataInicio);
		}
		else if (ValidarDataFim())
		{
			DataFim = DataFim.ToDateTimeDataFim();
			expression = x => (x.DataAlteracao <= DataFim);
		}
		else
		{
			return expression;
		}

		return expression;
	}
}
}
