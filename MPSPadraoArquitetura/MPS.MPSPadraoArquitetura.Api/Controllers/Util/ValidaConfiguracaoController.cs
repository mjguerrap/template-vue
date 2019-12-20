using MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MPS.MPSPadraoArquitetura.Api.Controllers.Util
{
    public class ValidaConfiguracaoController : ApiController
{
	private readonly IValidaConfiguracao _validaConfiguracao;

	public ValidaConfiguracaoController(IValidaConfiguracao validaConfiguracao)
	{
		_validaConfiguracao = validaConfiguracao;
	}

	// GET: ValidaConfiguracao
	[Route("api/Util/VersaoSistema")]
	public BaseRetorno Get()
	{
		return _validaConfiguracao.VersaoSistema();
	}

	// GET: ValidaConfiguracao
	[Route("api/Util/ValidarConection/{ambiente:alpha=}")]
	public BaseRetorno Get(string ambiente)
	{
		return _validaConfiguracao.ValidarConection(ambiente);
	}
}
}