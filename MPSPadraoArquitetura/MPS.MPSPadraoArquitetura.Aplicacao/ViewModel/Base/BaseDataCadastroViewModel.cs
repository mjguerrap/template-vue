using System;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base
{
    public class BaseDataCadastroViewModel : BaseDataAlteracaoViewModel
{
	public string UsuarioCadastro { get; set; }
	public DateTime DataCadastro { get; set; }
	public BaseDataCadastroViewModel()
	{
		Initialize();
	}
}
}
