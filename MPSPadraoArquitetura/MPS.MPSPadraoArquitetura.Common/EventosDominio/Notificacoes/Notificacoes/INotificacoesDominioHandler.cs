using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Notificacoes.Handlers
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : EventoDominio
{
	bool HasNotification();
	IList<T> GetNotifications();
}
}
