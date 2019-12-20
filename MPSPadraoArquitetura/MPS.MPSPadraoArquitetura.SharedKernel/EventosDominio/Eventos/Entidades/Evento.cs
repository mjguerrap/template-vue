using System;

namespace MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades
{
    public class Evento : EventoDominio
{
	public DateTime DateOccurred { get; protected set; }

	protected Evento()
	{
		DateOccurred = DateTime.Now;
	}
}
}
