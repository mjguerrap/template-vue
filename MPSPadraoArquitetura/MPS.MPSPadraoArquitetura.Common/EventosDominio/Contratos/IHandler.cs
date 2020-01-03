using System;
using MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Contratos
{
    public interface IHandler<in T> : IDisposable where T : EventoDominio
{
	void Handle(T message);
}
}
