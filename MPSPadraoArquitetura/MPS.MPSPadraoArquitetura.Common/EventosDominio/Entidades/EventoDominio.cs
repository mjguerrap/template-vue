using System;
using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Notificacoes.Handlers;

namespace MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Entidades
{
    public class EventoDominio
{
	public static IContainer Container { get; set; }

	public string EventType { get; protected set; }

	protected EventoDominio()
	{
		EventType = GetType().Name;
	}

	public static void RaiseEvent<T>(T theEvent) where T : Evento
	{
		if (Container == null)
		{
			return;
		}

		var obj = Container.GetService(theEvent.EventType.Equals("NotificacoesDominio") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

		((IHandler<T>)obj).Handle(theEvent);
	}
}
}
