using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TrackerEnabledDbContext.Common.Models;
using MPS.MPSPadraoArquitetura.Infra.Dados.UoW;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Audit;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Audit
{
    public class AuditLogsApp : ApplicationService, IAuditLogsApp
{
	private readonly IAuditLogsRepositorio _auditLogRepositorio;

	public AuditLogsApp(IUnitOfWork unitOfWork, IAuditLogsRepositorio auditLogsRepositorio) : base(unitOfWork)
	{
		_auditLogRepositorio = auditLogsRepositorio;
	}

	public IEnumerable<AuditLogViewModel> Selecionar(PesquisaAuditLogViewModel viewModel, out int total)
	{
		List<AuditLog> lista = _auditLogRepositorio.Selecionar(Mapper.Map<PesquisaAuditLogViewModel, PesquisaAuditLog>(viewModel), out total).ToList();

		List<AuditLogViewModel> listaRetorno = new List<AuditLogViewModel>();
		AuditLogViewModel auditLogViewModel = null;
		AuditLogDetailsViewModel auditLogDetailsViewModel = null;
		AuditLogMetadataViewModel auditLogMetadataViewModel = null;

		foreach (var item in lista)
		{
			auditLogViewModel = new AuditLogViewModel()
			{
				AuditLogId = item.AuditLogId.ToIdCrypt(),
				EventDateUtc = item.EventDateUTC,
				EventType = (int)item.EventType,
				RecordId = item.RecordId,
				TypeFullName = item.TypeFullName,
				UserName = item.UserName,

			};

			foreach (var logDetalhe in item.LogDetails)
			{
				auditLogDetailsViewModel = new AuditLogDetailsViewModel()
				{
					Id = logDetalhe.Id.ToIdCrypt(),
					AuditLogId = logDetalhe.AuditLogId.ToIdCrypt(),
					NewValue = logDetalhe.NewValue,
					OriginalValue = logDetalhe.OriginalValue,
					PropertyName = logDetalhe.PropertyName
				};

				auditLogViewModel.LogDetails.Add(auditLogDetailsViewModel);
			}

			foreach (var metadata in item.Metadata)
			{
				auditLogMetadataViewModel = new AuditLogMetadataViewModel()
				{
					Id = metadata.Id.ToIdCrypt(),
					AuditLogId = metadata.AuditLogId.ToIdCrypt(),
					Key = metadata.Key,
					Value = metadata.Value
				};

				auditLogViewModel.Metadata.Add(auditLogMetadataViewModel);
			}

			listaRetorno.Add(auditLogViewModel);
		}

		return listaRetorno;
	}

	public IEnumerable<AuditLogMetadataViewModel> SelecionarMetadata(long id)
	{
		List<LogMetadata> lista = _auditLogRepositorio.SelecionarMetadata(id).ToList();
		return Mapper.Map(lista, new List<AuditLogMetadataViewModel>());
	}

	public IEnumerable<string> SelecionarClassesLog()
	{
		return _auditLogRepositorio.SelecionarClassesDoLog().ToList();
	}
}
}
