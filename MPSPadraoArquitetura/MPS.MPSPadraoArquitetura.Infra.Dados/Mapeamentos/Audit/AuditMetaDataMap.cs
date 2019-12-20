using System.Data.Entity.ModelConfiguration;
using TrackerEnabledDbContext.Common.Models;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Audit
{
    public class AuditMetaDataMap : EntityTypeConfiguration<LogMetadata>
{
	public AuditMetaDataMap()
	{
		ToTable("LogMetadata", "Logs");

		Property(p => p.Key)
			.IsMaxLength()
			.HasColumnType("nvarchar");

		Property(p => p.Value)
			.IsMaxLength()
			.HasColumnType("nvarchar");
	}
}
}
