using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Util
{
    public static class ValidacaoViewModel
{
	public static string ObterMensagemErro(ModelStateDictionary ModelState)
	{
		StringBuilder mensagemErro = new StringBuilder();

		foreach (var value in ModelState.Values)
		{
			if (value.Errors.Any())
			{
				foreach (var item in value.Errors)
				{
					mensagemErro.AppendFormat("{0} <br />", item.ErrorMessage);
				}
			}
		}

		return mensagemErro.ToString();
	}
}
}