using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Base.Pesquisa;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Enum;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa
{
    public class PesquisaAuditLogViewModel : BasePesquisaViewModel
{
	[DataType(DataType.Text)]
	[Display(Name = "Matrícula")]
	public string Usuario { get; set; }

	[DataType(DataType.Text)]
	[Display(Name = "Entidade")]
	public string EntidadeSelecionada { get; set; }

	public IList<string> ListaEntidadeLog { get; set; }

	public EnumOpercaoAuditViewModel EnumOpercaoAuditViewModel { get; set; }

	public PesquisaAuditLogViewModel()
	{
		EnumOpercaoAuditViewModel = new EnumOpercaoAuditViewModel();
	}
}
}
