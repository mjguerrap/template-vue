using System;
using System.Collections.Generic;
using System.Linq;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Eventos;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Eventos.Handlers
{
    public class NotificacoesDominioHandler : IDomainNotificationHandler<NotificacoesDominio>
{
	private IList<NotificacoesDominio> _notifications;
	private readonly INotificacoesDominioRepositorio _notificacoesDominioRepositorio;

	public NotificacoesDominioHandler(INotificacoesDominioRepositorio notificacoesDominioRepositorio)
	{
		_notifications = new List<NotificacoesDominio>();
		_notificacoesDominioRepositorio = notificacoesDominioRepositorio;
	}

	public IList<NotificacoesDominio> GetNotifications()
	{
		return _notifications;
	}

	public void Handle(NotificacoesDominio message)
	{
		if (message != null && message.Erro)
		{
			_notificacoesDominioRepositorio.Inserir(message);
		}
		_notifications.Add(message);
	}

	public bool HasNotification()
	{
		return GetNotifications().Any();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_notifications = null;
		}
	}
}
}
