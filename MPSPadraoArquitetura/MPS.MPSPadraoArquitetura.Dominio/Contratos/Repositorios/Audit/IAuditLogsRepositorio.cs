using MPS.MPSPadraoArquitetura.Dominio.Entidades.Audit;
using System.Collections.Generic;
using TrackerEnabledDbContext.Common.Models;

namespace MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Audit
{
    public interface IAuditLogsRepositorio
{
	IEnumerable<AuditLog> Selecionar(PesquisaAuditLog pesquisa, out int total);

	IEnumerable<LogMetadata> SelecionarMetadata(long id);

	IEnumerable<string> SelecionarClassesDoLog();

}
}
