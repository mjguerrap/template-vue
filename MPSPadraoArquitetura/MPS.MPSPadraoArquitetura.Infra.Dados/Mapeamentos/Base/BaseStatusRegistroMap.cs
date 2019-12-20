using System.Data.Entity.ModelConfiguration;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Base
{
    public class BaseStatusRegistroMap : EntityTypeConfiguration<BaseStatusRegistro>
{
	public BaseStatusRegistroMap()
		: base()
	{
		// Primary Key
		this.HasKey(t => t.StatusId);
		//Adicionar tipo de dado correto

		// Table & Column Mappings
		this.ToTable("StatusRegistro", "Tipo");
		this.Property(t => t.Descricao)
			.HasColumnName("Descricao")
			.HasMaxLength(50);

		this.Property(t => t.StatusId)
		   .HasColumnName("StatusId")
		   .IsRequired();

	}
}
}
