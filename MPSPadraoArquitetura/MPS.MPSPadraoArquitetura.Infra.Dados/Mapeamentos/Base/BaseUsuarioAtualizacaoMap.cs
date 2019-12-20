using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Base
{
    public class BaseUsuarioAtualizacaoMap<T> : BaseMap<T> where T : BaseUsuarioAlteracao
{
	public BaseUsuarioAtualizacaoMap()
	{
		this.Property(t => t.DataAlteracao)
			.HasColumnName("DataAlteracao")
			.HasColumnType("DATETIME2")
			.HasPrecision(2)
			.IsRequired();

		this.Property(t => t.UsuarioAlteracao)
			.HasColumnName("UsuarioAlteracao")
			.HasColumnType("VARCHAR")
			.HasMaxLength(25)
			.IsRequired();


	}
}
}
