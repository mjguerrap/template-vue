using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Notificacoes;

namespace MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Eventos
{
    public interface INotificacoesDominioRepositorio
{
	void Inserir(NotificacoesDominio entity);
}
}
