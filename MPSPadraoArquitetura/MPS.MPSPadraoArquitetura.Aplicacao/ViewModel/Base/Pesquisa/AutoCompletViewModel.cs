using System;
using System.Collections.Generic;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base.Pesquisa
{
    public class AutoCompletViewModel
{
	public IEnumerable<BaseAutoCompletViewModel> ListaObjetos { get; set; }
	public int TotalRegistros { get; set; }
}
}
