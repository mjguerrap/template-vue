using System.Configuration;
using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Web.Controllers
{
    public class HomeController : Controller
{
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult Sair()
	{
		const string appSettingsLogOff = "UrlSair";
		var logOff = ConfigurationManager.AppSettings[appSettingsLogOff];

		if (string.IsNullOrWhiteSpace(logOff))
		{
			throw new ConfigurationErrorsException(string.Format("Nao foi encontrado uma AppSettings '{0}'", appSettingsLogOff));
		}
		return Redirect(logOff);
	}
}
}