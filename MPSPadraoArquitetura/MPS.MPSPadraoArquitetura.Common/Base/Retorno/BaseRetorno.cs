using System.Runtime.Serialization;

namespace MPS.MPSPadraoArquitetura.Domain.Common.Base.Retorno
{
	[DataContract]
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
