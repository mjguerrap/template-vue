using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MPS.MPSPadraoArquitetura.SharedKernel.Enum.Audit;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Enum
{
    public class EnumOpercaoAuditViewModel
{
	[DataType(DataType.Text)]
	[Display(Name = "Tipo Operação")]
	public int TipoOpercaoId { get; set; }

	public string Descricao { get; set; }

	OperacaoEnum OpercaoEnum { get { return (OperacaoEnum)TipoOpercaoId; } }

	public Dictionary<int, string> TipoOpercaoSelecionar { get; set; }

	public EnumOpercaoAuditViewModel()
	{
		bool inicial = true;

		TipoOpercaoSelecionar = new Dictionary<int, string>();
		foreach (OperacaoEnum item in System.Enum.GetValues(typeof(OperacaoEnum)))
		{
			if (inicial)
			{
				TipoOpercaoSelecionar.Add(-1, "Selecione...");
				inicial = false;
			}

			TipoOpercaoSelecionar.Add(item.ToByte(), item.GetEnumDisplayName());

		}
	}

}
}
