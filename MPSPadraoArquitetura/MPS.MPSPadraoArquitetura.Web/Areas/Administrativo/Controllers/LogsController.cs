using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Util;
using MPS.MPSPadraoArquitetura.Web.Controllers.Base;
using MPS.MPSPadraoArquitetura.Web.Filters;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;


namespace MPS.MPSPadraoArquitetura.Web.Areas.Administrativo.Controllers
{
    [AutorizacaoCustom(Roles = "MPS_Analistas")]
public class LogsController : BaseController
{
	private readonly IAuditLogsApp _auditLogsAppService;

	public LogsController(IAuditLogsApp auditLogAppService)
	{
		_auditLogsAppService = auditLogAppService;
	}

	public ActionResult LogsElmah()
	{
		return View();
	}

	public ActionResult LogsAudit()
	{
		PesquisaAuditLogViewModel viewModel = new PesquisaAuditLogViewModel
		{
			ListaEntidadeLog = new List<string>(_auditLogsAppService.SelecionarClassesLog())
		};
		viewModel.EnumOpercaoAuditViewModel.TipoOpercaoId = -1;

		return View(viewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public JsonResult Pesquisar(PesquisaAuditLogViewModel viewModel)
	{
		if (!ModelState.IsValid)
		{
			object retorno = new
			{
				Notificacao = true,
				Mensagem = ValidacaoViewModel.ObterMensagemErro(ModelState),
				ListaRetorno = "[]",
				PesquisaEquipeViewModel = JsonConvert.SerializeObject(viewModel)
			};

			return Json(retorno, JsonRequestBehavior.AllowGet);
		}

		viewModel.DataInicio = viewModel.PesquisaDataInicio.ToDateTime();
		viewModel.DataFim = viewModel.PesquisaDataFim.ToDateTime().ToDateTimeDataFim();

		var lista = _auditLogsAppService.Selecionar(viewModel, out int total);

		var listaRetorno = JsonConvert.SerializeObject(lista, new IsoDateTimeConverter());

		return Json(ValidarNotificacao(listaRetorno, total.ToString()), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public JsonResult PesquisarMetadata(long id)
	{
		object retorno;

		if (id == 0 || id < 0)
		{
			retorno = new { Notificacao = true, Mensagem = "Log informado é Inválido!" };
			return Json(retorno, JsonRequestBehavior.AllowGet);
		}

		var lista = _auditLogsAppService.SelecionarMetadata(id.ToIdDecrypt());
		var listaRetorno = JsonConvert.SerializeObject(lista, new IsoDateTimeConverter());

		retorno = new { Notificacao = !listaRetorno.Any(), ListaRetorno = listaRetorno, Mensagem = "Log sem Metadata!" };
		return Json(retorno, JsonRequestBehavior.AllowGet);
	}

}
}