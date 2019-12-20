using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.Enum.Base;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base
{
    public class BaseId
{
	public int Id { get; set; }

	public BaseStatusRegistro StatusRegistro { get; set; }

	public byte StatusRegistroId { get; set; }

#pragma warning disable S3400

	public virtual bool ValidarEntidade()
	{
		return false;
	}

	public virtual bool ValidarEntidadeAlteracao()
	{
		return false;
	}

	public virtual bool ValidarEntidadeExclusao()
	{
		return false;
	}
#pragma warning restore S3400

	public virtual bool ValidarEntidadeExclusao(bool objFilho)
	{
		return false;
	}

	public virtual void Reativar()
	{
		StatusRegistroId = (byte)StatusRegistroEnum.Ativo;
	}

	public virtual void Desativar()
	{
		StatusRegistroId = (byte)StatusRegistroEnum.Inativo;
	}

}
}
