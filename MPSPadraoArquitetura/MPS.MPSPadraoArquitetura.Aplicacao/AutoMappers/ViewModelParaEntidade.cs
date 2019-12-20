using AutoMapper;
using TrackerEnabledDbContext.Common.Models;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base.Pesquisa;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Audit;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers
{
    public class ViewModelParaEntidade : Profile
{
	public ViewModelParaEntidade()
	{
		Base();
		Logs();
		Pesquisa();
	}

	private void Base()
	{
		CreateMap<BaseStatusRegistroViewModel, BaseStatusRegistro>()
			.AfterMap((x, y) => y.Descricao = y.Descricao.Trim());

		CreateMap<BasePesquisaViewModel, BasePesquisa>();

		CreateMap<BaseAutoCompletViewModel, BaseAutoComplet>()
			.AfterMap((x, y) => y.Id = y.Id.ToIdDecrypt());
	}

	private void Logs()
	{
		CreateMap<AuditLogDetailsViewModel, AuditLogDetail>()
			.AfterMap((x, y) => y.Id = y.Id.ToIdDecrypt())
			.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdDecrypt());

		CreateMap<AuditLogMetadataViewModel, LogMetadata>()
			.AfterMap((x, y) => y.Id = y.Id.ToIdDecrypt())
			.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdDecrypt());

		CreateMap<AuditLogViewModel, LogMetadata>()
			.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdCrypt());

		CreateMap<PesquisaAuditLogViewModel, PesquisaAuditLog>()
			.AfterMap((x, y) => y.EntidadeSelecionada = x.EntidadeSelecionada)
			.AfterMap((x, y) => y.TipoOpercaoId = x.EnumOpercaoAuditViewModel.TipoOpercaoId);
	}

	private void Pesquisa()
	{
		CreateMap<AutoCompletViewModel, AutoComplet>();


	}


}
}
