using System;
using System.Collections.Generic;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo
{
    public class AuditLogViewModel
{
	public long AuditLogId { get; set; } // ID da tabela (PK)

	public string UserName { get; set; } // Matrícula do usuário que fez a ação

	public DateTime EventDateUtc { get; set; } // Data da ação

	public int EventType { get; set; } // Tipo do Evento

	public string TypeFullName { get; set; } // Local do Evento

	public string RecordId { get; set; } // ID da Gravação

	public ICollection<AuditLogDetailsViewModel> LogDetails { get; set; }

	public ICollection<AuditLogMetadataViewModel> Metadata { get; set; }

	public AuditLogViewModel()
	{
		LogDetails = new List<AuditLogDetailsViewModel>();
		Metadata = new List<AuditLogMetadataViewModel>();
	}
}

}
