using System;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base
{
    public class BaseDataAlteracaoViewModel : BaseStatusRegistroViewModel
{
	public string UsuarioAlteracao { get; set; }
	public DateTime DataAlteracao { get; set; }
	public BaseDataAlteracaoViewModel()
	{
		Initialize();
	}
}
}
