using System;
using System.Collections.Generic;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base
{
    /// <summary>
    /// Class para identificar o usuário e a data de cadastro do registro
    /// Está class deve ser herdada quando as informações forem extremamente útil para a regra de negócio.
    /// </summary>
    public class BaseUsuarioCadastro : BaseUsuarioAlteracao
{
	public string UsuarioCadastro { get; set; }

	public DateTime DataCadastro { get; set; }
}
}
