using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Dominio.Entidades.Base;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Base
{
    public class BaseUsuarioCadastroMap<T> : BaseUsuarioAtualizacaoMap<T> where T : BaseUsuarioCadastro
{
	public BaseUsuarioCadastroMap()
	{
		this.Property(t => t.DataCadastro)
			.HasColumnName("DataCadastro")
			.HasColumnType("DATETIME2")
			.HasPrecision(2)
			.IsRequired();

		this.Property(t => t.UsuarioCadastro)
			.HasColumnName("UsuarioCadastro")
			.HasColumnType("VARCHAR")
			.HasMaxLength(25)
			.IsRequired();
	}
}
}
