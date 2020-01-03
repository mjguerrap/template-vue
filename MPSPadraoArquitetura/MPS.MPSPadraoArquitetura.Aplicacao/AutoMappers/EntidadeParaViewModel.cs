using AutoMapper;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;

namespace MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers
{
	public class EntidadeParaViewModel : Profile
{
	public EntidadeParaViewModel()
	{
		Base();
		Logs();
		Pesquisa();
	}

	private void Base()
	{
		CreateMap<BaseStatusRegistro, BaseStatusRegistroViewModel>();

		//CreateMap<BasePesquisa, BasePesquisaViewModel>();

		//CreateMap<BaseAutoComplet, BaseAutoCompletViewModel>()
		//	.AfterMap((x, y) => y.Id = y.Id.ToIdCrypt()); ;
	}

	private void Logs()
	{
		//CreateMap<AuditLogDetail, AuditLogDetailsViewModel>()
		//	.AfterMap((x, y) => y.Id = y.Id.ToIdCrypt())
		//	.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdCrypt());

		//CreateMap<LogMetadata, AuditLogMetadataViewModel>()
		//	.AfterMap((x, y) => y.Id = y.Id.ToIdCrypt())
		//	.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdCrypt());

		//CreateMap<LogMetadata, AuditLogViewModel>()
		//	.AfterMap((x, y) => y.AuditLogId = y.AuditLogId.ToIdCrypt());

		//CreateMap<PesquisaAuditLog, PesquisaAuditLogViewModel>()
		//   .AfterMap((x, y) => y.EntidadeSelecionada = x.EntidadeSelecionada)
		//   .AfterMap((x, y) => y.EnumOpercaoAuditViewModel.TipoOpercaoId = x.TipoOpercaoId);
	}

	private void Pesquisa()
	{
		//CreateMap<AutoComplet, AutoCompletViewModel>();


	}


}
}
