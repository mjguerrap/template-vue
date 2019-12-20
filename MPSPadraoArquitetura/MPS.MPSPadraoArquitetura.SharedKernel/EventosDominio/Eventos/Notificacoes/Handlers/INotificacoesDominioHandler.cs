using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : EventoDominio
{
	bool HasNotification();
	IList<T> GetNotifications();
}
}
