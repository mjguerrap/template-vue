using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;

namespace MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Eventos
{
    public interface INotificacoesDominioRepositorio
{
	void Inserir(NotificacoesDominio entity);
}
}
