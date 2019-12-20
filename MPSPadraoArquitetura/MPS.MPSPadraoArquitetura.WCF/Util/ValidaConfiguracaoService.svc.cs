using MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;

namespace MPS.MPSPadraoArquitetura.WCF.Util
{
    public class ValidaConfiguracaoService : IValidaConfiguracaoService
{
	private readonly IValidaConfiguracao _validaConfiguracao;

	public ValidaConfiguracaoService(IValidaConfiguracao validaConfiguracao)
	{
		_validaConfiguracao = validaConfiguracao;
	}

	public BaseRetorno ValidarConection(string ambiente)
	{
		return _validaConfiguracao.ValidarConection(ambiente);
	}

	public BaseRetorno VersaoSistema()
	{
		return _validaConfiguracao.VersaoSistema();
	}
}
}
