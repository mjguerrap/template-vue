using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using TrackerEnabledDbContext.Common.Models;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Audit;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Audit;
using MPS.MPSPadraoArquitetura.Infra.Dados.Contextos;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Map;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Repositorios.Audit
{
    public class AuditLogsRepositorio : IAuditLogsRepositorio
{
	private readonly Contexto _contexto;
	private readonly AuditLogDataTablesMap _auditLogDataTablesMap;

	public AuditLogsRepositorio(Contexto contexto, AuditLogDataTablesMap auditLogDataTablesMap)
	{
		_contexto = contexto;
		_auditLogDataTablesMap = auditLogDataTablesMap;
	}

	public IEnumerable<AuditLog> Selecionar(PesquisaAuditLog pesquisa, out int total)
	{
		if (pesquisa == null)
		{
			throw new ArgumentNullException("pesquisa", "Paramentro não pode ser Null");
		}
		if (pesquisa.ValidarPossuiFiltros())
		{
			var query = _contexto.AuditLog.Include(x => x.LogDetails).AsQueryable();

			if (pesquisa.ValidarEntidade())
			{
				query = query.Where(pesquisa.PorEntidade());
			}
			if (pesquisa.ValidarUsuario())
			{
				query = query.Where(pesquisa.PorUsuario());
			}
			if (pesquisa.ValidarTipoOperacaoId())
			{
				query = query.Where(pesquisa.PorTipoOpercaoId());
			}
			if (pesquisa.ValidarDataInicio() || pesquisa.ValidarDataFim())
			{
				query = query.Where(pesquisa.PorPeriodo());
			}

			total = query.Count();

			var column = _auditLogDataTablesMap.GetProperty(pesquisa.GetNomeColunaOrdenada());

			query = pesquisa.GetDirecaoColunaOrdenada() == DirecaoOrdenacaoDataTableEnum.Asc.ToString() ? query.OrderByProperty(column) : query.OrderByPropertyDescending(column);

			var lista = query.Skip(pesquisa.Start).Take(pesquisa.Length).ToList();
			return lista;
		}

		total = 0;
		return new List<AuditLog>();
	}

	public IEnumerable<LogMetadata> SelecionarMetadata(long id)
	{
		return _contexto.AuditLog.Include(x => x.Metadata).Where(x => x.AuditLogId == id).SelectMany(x => x.Metadata).ToList();
	}

	public IEnumerable<string> SelecionarClassesDoLog()
	{
		return _contexto.AuditLog.Select(x => x.TypeFullName).Distinct();
	}

}
}

