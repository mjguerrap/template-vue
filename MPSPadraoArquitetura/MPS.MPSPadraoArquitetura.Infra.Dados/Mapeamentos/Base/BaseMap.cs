using System.Data.Entity.ModelConfiguration;
using TrackerEnabledDbContext.Common.Extensions;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Base
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseId
{
	public BaseMap()
	{
		this.TrackAllProperties();
		this.HasKey(t => t.Id);
		this.HasRequired(t => t.StatusRegistro)
			.WithMany()
			.HasForeignKey(t => t.StatusRegistroId);
	}

}
}
