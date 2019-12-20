using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Web.Controllers
{
    [AllowAnonymous]
public class ConteudoEstaticoController : Controller
{
	public ActionResult Erro404()
	{
		return View();
	}

	public ActionResult PaginaNaoAutorizada()
	{
		return View();
	}

}
}