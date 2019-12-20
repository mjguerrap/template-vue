using System;
using System.Collections.Generic;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base
{
    /// <summary>
    /// Class para identificar o usuário e a data de alteracao do registro
    /// Está class deve ser herdada quando as informações forem extremamente útil para a regra de negócio.
    /// </summary>
    public class BaseUsuarioAlteracao : BaseId
{
	public string UsuarioAlteracao { get; set; }

	public DateTime DataAlteracao { get; set; }
}
}
