using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Web.Controllers
{
    public class GestaoAvisoController : Controller
{
	public ActionResult Aviso()
	{
		return View();
	}

	public ActionResult NovoAviso()
	{
		return View();
	}

	public ActionResult EditarAviso(int idAviso)
	{
		return View();
	}

	public ActionResult Categoria()
	{
		return View();
	}

	public ActionResult NovoCategoria()
	{
		return View();
	}

	public ActionResult EditarCategoria(int idCategoriaAviso)
	{
		return View();
	}

	public ActionResult AvisoDetalhes(int idAviso)
	{
		return View();
	}

	public ActionResult VisualizarAnexo(int idAviso)
	{
		var apiUrl = $"{WebConfigurationManager.AppSettings["MPSComponenteAvisoAPI"]}Anexo/ObterConteudoAnexo/{idAviso}";

		WebClient c = new WebClient();
		byte[] retorno = c.DownloadData(apiUrl);
		c.Dispose();

		if (retorno != null)
		{
			return File(retorno, System.Net.Mime.MediaTypeNames.Application.Pdf);
		}

		return RedirectToAction("PaginaNaoAutorizada", "ConteudoEstatico");
	}
}
}
