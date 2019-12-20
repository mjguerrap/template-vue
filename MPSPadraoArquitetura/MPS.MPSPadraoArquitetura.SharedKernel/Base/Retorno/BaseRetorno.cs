using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno
{
    [DataContractAttribute]
public class BaseRetorno
{
	/// <summary>
	/// Método para complementar o retorno do Serviço 
	/// </summary>
	/// <param name="resultado">Variável para identificar Valido ou não</param>
	/// <param name="retornoMensagem">Mensagem para notificar erros o alertas </param>
	public BaseRetorno(bool resultado, string retornoMensagem)
	{
		Resultado = resultado;
		RetornoMensagem = retornoMensagem;
	}

	[DataMember]
	public bool Resultado { get; private set; }

	[DataMember]
	public string RetornoMensagem { get; private set; }
}
}
