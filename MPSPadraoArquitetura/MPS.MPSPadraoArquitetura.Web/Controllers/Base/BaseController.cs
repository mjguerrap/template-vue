using System.Web.Mvc;
using System.Linq;
using MPS.SSO.CustomClaims;
using MPS.MPSPadraoArquitetura.SharedKernel.Resource;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Log;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers;
using MPS.MPSPadraoArquitetura.Web.HtmlHelpers;

namespace MPS.MPSPadraoArquitetura.Web.Controllers.Base
{
    public class BaseController : Controller
{
	private readonly IDomainNotificationHandler<NotificacoesDominio> _notifications = EventoDominio.Container.GetService<IDomainNotificationHandler<NotificacoesDominio>>();

	protected BaseController() { }

	public IDomainNotificationHandler<NotificacoesDominio> Notifications
	{
		get
		{
			return _notifications;
		}
	}

	protected string ObterMensagensNotificacoesDominio()
	{
		var notificacoes = _notifications.GetNotifications();

		string mensagens = string.Empty;

		if (notificacoes != null)
		{
			for (int i = 0; i < notificacoes.Count; i++)
			{
				if (i == 0)
				{
					mensagens = notificacoes[i].Valor;
				}
				else
				{
					mensagens += "<br />" + notificacoes[i].Valor;
				}
			}

		}

		return mensagens;
	}

	/// <summary>
	/// Método para Validar as Notificações de Pesquisa sem valores ou Valores Datas Invalidas 
	/// </summary>
	/// <param name="listaRetorno"></param>
	/// <param name="total"></param>
	/// <returns></returns>
	protected object ValidarNotificacao(string listaRetorno, string total)
	{
		object retorno;
		if (_notifications.GetNotifications().Any(x => x.Chave == "ParametrosPesquisa"))
		{
			retorno = new
			{
				Notificacao = true,
				Mensagem = MensagensPadrao.PesquisaSemParametro,
				ListaRetorno = listaRetorno,
				Total = total
			};
		}
		else
		{
			var validaDataInicioFim = _notifications.GetNotifications().FirstOrDefault(x => x.Chave == "ValidarDataInicioDataFim");

			retorno = new
			{
				Notificacao = !Equals(validaDataInicioFim, null),
				Mensagem = !Equals(validaDataInicioFim, null) ? validaDataInicioFim.Valor : "Nenhum Registro encontrado!",
				ListaRetorno = listaRetorno,
				Total = total
			};
		}

		return retorno;
	}

	/// <summary>
	/// Método para obter informações de LOG (IP, Browser, SitemaOperacional, Dispositivo e UsuarioLogado) para gravar essas informações no banco de dados. 
	/// </summary>
	/// <returns></returns>
	public InformacoesDeLogViewModel ObterInformacoesDeLog()
	{
		InformacoesDeLogViewModel informacoesDeLogViewModel = new InformacoesDeLogViewModel
		{
			UsuarioLogado = HelperClaim.ObterValorClaim(Claims.IdentityProvider),
			UsuarioLogadoMatricula = HelperClaim.ObterValorClaim(Claims.Matricula),
			Ip = Request.UserHostAddress,
			Browser = Request.Browser.Browser,
		};

		if (Request.UserAgent.ToUpper().Contains("EDGE"))
		{
			informacoesDeLogViewModel.Browser = "Edge";
		}

		if (Request.Browser.Browser.ToUpper().Contains("INTERNETEXPLORER"))
		{
			informacoesDeLogViewModel.Browser = "Internet Explorer";
		}

		if (Request.Browser.IsMobileDevice)
		{
			informacoesDeLogViewModel.SitemaOperacional = Request.Browser.MobileDeviceModel;
			informacoesDeLogViewModel.Dispositivo = "Mobile";
		}
		else
		{
			informacoesDeLogViewModel.SitemaOperacional = !string.IsNullOrEmpty(Request.Browser.Platform) && Request.Browser.Platform.ToUpper().Contains("WIN") ? "Windows" : Request.Browser.Platform;
			informacoesDeLogViewModel.Dispositivo = "Desktop";
		}

		return informacoesDeLogViewModel;
	}
}
}