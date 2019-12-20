using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Enum;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base
{
    public class BaseStatusRegistroViewModel
{
	public int Id { get; set; }

	public EnumStatusRegistroViewModel EnumStatusRegistroViewModel { get; set; }

	public void Initialize()
	{
		if (EnumStatusRegistroViewModel == null)
		{
			EnumStatusRegistroViewModel = new EnumStatusRegistroViewModel();
		}
	}

}
}
