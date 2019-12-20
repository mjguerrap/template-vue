using System.Data.Entity.ModelConfiguration;
using TrackerEnabledDbContext.Common.Models;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Audit
{
    public class AuditLogsDetailsMap : EntityTypeConfiguration<AuditLogDetail>
{
	public AuditLogsDetailsMap()
	{
		ToTable("AuditLogDetails", "Logs");

		Property(x => x.PropertyName)
			.HasMaxLength(256).IsRequired();

		Property(p => p.OriginalValue)
			.IsMaxLength()
			.HasColumnType("nvarchar");

		Property(p => p.NewValue)
			.IsMaxLength()
			.HasColumnType("nvarchar");
	}
}
}
