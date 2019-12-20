using System.Data.Entity.ModelConfiguration;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Eventos
{
    public class NotificacoesDominioMap : EntityTypeConfiguration<NotificacoesDominio>
{
	public NotificacoesDominioMap()
	{
		ToTable("NotificacoesDominio", "Eventos");

		HasKey(t => t.IdNotificacaoDominio);
		Property(t => t.Valor);
		Property(t => t.Chave);
		Property(t => t.TipoObjeto)
			.HasColumnName("TipoObjeto");
		Ignore(t => t.Type);
		Property(t => t.Erro);
		Property(t => t.Ex)
			.HasColumnType("varchar")
			.HasColumnName("ExceptionAplication");
		Property(t => t.DateOccurred)
			.HasColumnType("DATETIME")
			.HasPrecision(2);

		this.Property(t => t.Valor)
			.HasColumnName("Valor")
			.IsRequired()
			.HasMaxLength(750);

	}
}
}
