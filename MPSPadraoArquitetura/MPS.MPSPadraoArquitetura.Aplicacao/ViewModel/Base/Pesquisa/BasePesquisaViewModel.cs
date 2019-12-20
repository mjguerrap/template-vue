using System;
using System.ComponentModel.DataAnnotations;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Enum;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base.Pesquisa
{
    public class BasePesquisaViewModel : ParametrosDataTables
{
	[RegularExpression("([0-9]([0-9]?))", ErrorMessage = "* Matrícula Inválida")]
	public int Matricula { get; set; }

	public string NomeFuncionario { get; set; }

	public DateTime DataInicio { get; set; }

	public DateTime DataFim { get; set; }

	public string PesquisaDataInicio { get; set; }

	public string PesquisaDataFim { get; set; }

	public bool ManterPesquisa { get; set; }

	public EnumStatusRegistroViewModel EnumStatusRegistroViewModel { get; set; }

	public BasePesquisaViewModel()
	{
		EnumStatusRegistroViewModel = new EnumStatusRegistroViewModel();
	}

}
}
