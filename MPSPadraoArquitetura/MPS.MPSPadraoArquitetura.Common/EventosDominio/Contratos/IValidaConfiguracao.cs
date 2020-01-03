using MPS.MPSPadraoArquitetura.Domain.Common.Base.Retorno;

namespace MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Contratos
{
	public interface IValidaConfiguracao
{
	BaseRetorno VersaoSistema();
	BaseRetorno ValidarConection(string ambiente);
}
}
