using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa
{
    public class AutoComplet
{
	public IEnumerable<BaseAutoComplet> ListaObjetos { get; set; }
	public int TotalRegistros { get; set; }
}
}
