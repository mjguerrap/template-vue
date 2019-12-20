using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using TrackerEnabledDbContext.Common.Models;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.Resource;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Audit
{
    public class PesquisaAuditLog : BasePesquisa
{
	public int TipoOpercaoId { get; set; }

	public string EntidadeSelecionada { get; set; }

	public int Usuario { get; set; }

	#region Validações

	/// <summary>
	/// Verifica se Objeto de Pesquisa tem algum filtro preenchido
	/// </summary>
	/// <returns>bool</returns>
	public virtual bool ValidarPossuiFiltros()
	{
		bool retorno = ValidacoesDominio.IsValidExistTrue(ValidarUsuario(), ValidarTipoOperacaoId(), ValidarEntidade(), ValidarDatas(), ValidarDataInicio(), ValidarDataFim());

		if (!retorno)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio(MensagensPadrao.ParametroPesquisa, MensagensPadrao.PesquisaSemParametro, GetType()));
		}

		return retorno;
	}

	/// <summary>
	/// Verifica se Matrícula do usuário informada é válida
	/// </summary>
	/// <returns>bool</returns>
	public virtual bool ValidarUsuario()
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorQueEsperado(Usuario, 0, "Usuário inválido", GetType()));
	}

	/// <summary>
	/// Verifica se o Tipo de Operação é válido
	/// </summary>
	/// <returns>bool</returns>
	public virtual bool ValidarTipoOperacaoId()
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorQueEsperado(TipoOpercaoId, -1, "Operação Inválida", GetType()));
	}

	/// <summary>
	/// Verifica se a Entidade selecionada é válida
	/// </summary>
	/// <returns></returns>
	public virtual bool ValidarEntidade()
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula(EntidadeSelecionada, "Entidade inválida", GetType()));
	}

	#endregion Validações

	#region Parametros Pesquisa

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem para Expressao de pesquisa Por Entidade
	/// </summary>
	/// <returns></returns>
	public Expression<Func<AuditLog, bool>> PorEntidade()
	{
		Expression<Func<AuditLog, bool>> expression = x => x.TypeFullName == EntidadeSelecionada;
		return expression;
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem para Expressao de pesquisa Por Usuário 
	/// </summary>
	/// <returns></returns>
	public Expression<Func<AuditLog, bool>> PorUsuario()
	{
		Expression<Func<AuditLog, bool>> expression = x => x.UserName == Usuario.ToString();
		return expression;
	}

	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem para Expressao de pesquisa Por Tipo do Evento (Operação) 
	/// </summary>
	/// <returns></returns>
	public Expression<Func<AuditLog, bool>> PorTipoOpercaoId()
	{
		Expression<Func<AuditLog, bool>> expression = x => x.EventType == (EventType)TipoOpercaoId;
		return expression;
	}


	[ExcludeFromCodeCoverage]
	/// <summary>
	/// Montagem de Expressao de pesquisa por Periodo de Cadastro
	/// </summary>
	/// <returns></returns>
	public Expression<Func<AuditLog, bool>> PorPeriodo()
	{
		Expression<Func<AuditLog, bool>> expression = null;

		if (ValidarDatas())
		{
			expression = x => (x.EventDateUTC >= DataInicio && x.EventDateUTC <= DataFim);
		}
		else if (ValidarDataInicio())
		{
			expression = x => (x.EventDateUTC >= DataInicio);
		}
		else if (ValidarDataFim())
		{
			expression = x => (x.EventDateUTC <= DataFim);
		}
		else
		{
			return expression;
		}

		return expression;
	}

	#endregion Parametros Pesquisa
}
}
