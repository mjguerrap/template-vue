using System;

namespace MPS.MPSPadraoArquitetura.Domain.Common.EventosDominio.Eventos.Entidades
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
