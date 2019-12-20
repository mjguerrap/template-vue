using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MPS.MPSPadraoArquitetura.SharedKernel.Enum.Base;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Enum
{
    public class EnumStatusRegistroViewModel
{
	[Display(Name = "Status")]
	public byte StatusRegistroId { get; set; }

	StatusRegistroEnum StatusRegistroEnum { get { return (StatusRegistroEnum)StatusRegistroId; } }

	public Dictionary<int, string> StatusRegistroSelecionar { get; set; }

	public EnumStatusRegistroViewModel()
	{
		StatusRegistroSelecionar = new Dictionary<int, string>();
		foreach (StatusRegistroEnum item in System.Enum.GetValues(typeof(StatusRegistroEnum)))
		{
			StatusRegistroSelecionar.Add(item.ToByte(), item.GetEnumDisplayName());
		}
	}

}
}
