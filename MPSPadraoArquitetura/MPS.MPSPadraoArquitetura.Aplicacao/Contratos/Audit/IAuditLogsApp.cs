using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Audit
{
    public interface IAuditLogsApp
{
	IEnumerable<AuditLogViewModel> Selecionar(PesquisaAuditLogViewModel viewModel, out int total);

	IEnumerable<AuditLogMetadataViewModel> SelecionarMetadata(long id);

	IEnumerable<string> SelecionarClassesLog();
}
}
