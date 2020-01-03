using System.ComponentModel;

namespace MPS.MPSPadraoArquitetura.Domain.Common.Enum.Base
{
    [Description(description: "Status de Registro")]
    public enum StatusRegistroEnum
    {
        Inativo = 0,
        Ativo = 1,
        Excluido = 2
    }
}
