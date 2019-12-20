using System;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo
{
    public class AuditLogMetadataViewModel
{
	public long Id { get; set; } // ID da tabela (PK)

	public long AuditLogId { get; set; } // Id da tabela AuditLog (FK)

	public string Key { get; set; } // Chave

	public string Value { get; set; } // Valor

}
}
