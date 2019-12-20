using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Log;
using MPS.MPSPadraoArquitetura.Infra.Dados.UoW;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Base
{
    public class ApplicationService
{
	private readonly IDomainNotificationHandler<NotificacoesDominio> _notifications;
	private readonly IUnitOfWork _unitOfWork;

	protected ApplicationService(IUnitOfWork unitOfWork)
	{
		_notifications = EventoDominio.Container.GetService<IDomainNotificationHandler<NotificacoesDominio>>();
		_unitOfWork = unitOfWork;
	}

	protected void BeginTran()
	{
		_unitOfWork.BeginTrasaction();
	}

	protected void Commit()
	{
		_unitOfWork.Commit();
	}

	protected void RollBack()
	{
		_unitOfWork.Rollback();
	}

	protected void RequestLogMetaData(InformacoesDeLogViewModel viewModel)
	{
		_unitOfWork.RequestLogMetaData(viewModel.Ip, viewModel.Browser, viewModel.SitemaOperacional, viewModel.Dispositivo, viewModel.UsuarioLogado, viewModel.UsuarioLogadoMatricula);
	}

	protected bool Salvar(string usuarioLogado)
	{
		if (_notifications.HasNotification())
		{
			return false;
		}

		_unitOfWork.Salvar(usuarioLogado);
		return true;
	}

}
}
