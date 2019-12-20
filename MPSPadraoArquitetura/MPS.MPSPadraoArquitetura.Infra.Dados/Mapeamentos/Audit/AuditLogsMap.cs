using System.Data.Entity.ModelConfiguration;
using TrackerEnabledDbContext.Common.Models;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Audit
{
    public class AuditLogsMap : EntityTypeConfiguration<AuditLog>
{
	public AuditLogsMap()
	{
		ToTable("AuditLogs", "Logs");

		HasMany(x => x.LogDetails)
			.WithRequired()
			.HasForeignKey(fk => fk.AuditLogId);

		Property(x => x.UserName)
			.IsMaxLength()
			.HasColumnType("nvarchar");

		Property(x => x.EventDateUTC)
			.IsRequired();

		Property(x => x.EventType)
			.IsRequired();

		Property(x => x.TypeFullName)
			.HasMaxLength(512).IsRequired();

		Property(x => x.RecordId)
			.HasMaxLength(256).IsRequired();
	}
}
}
