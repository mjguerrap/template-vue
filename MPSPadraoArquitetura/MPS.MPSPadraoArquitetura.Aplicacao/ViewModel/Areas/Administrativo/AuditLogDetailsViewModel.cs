using System;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo
{
    public class AuditLogDetailsViewModel
{
	public long Id { get; set; } // ID da tabela (PK)

	public string PropertyName { get; set; } // Propriedade afetada

	public string OriginalValue { get; set; } // Valor Original

	public string NewValue { get; set; } // Valor Alterado

	public long AuditLogId { get; set; } // Id da tabela AuditLog (FK)

}
}
