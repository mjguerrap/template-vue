using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Web.Controllers.Base
{
    public static class ListaStatusRegistro
{
	public static SelectList DropDownStatusRegistro()
	{
		SelectList listaStatusRegistro = new SelectList(new[]
		{
				new { Value = 0, Text = "Inativo" },
				new { Value = 1, Text = "Ativo" }
			}, "Value", "Text");

		return listaStatusRegistro;
	}
}
}