using System;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos
{
    public interface IHandler<in T> : IDisposable where T : EventoDominio
{
	void Handle(T message);
}
}
