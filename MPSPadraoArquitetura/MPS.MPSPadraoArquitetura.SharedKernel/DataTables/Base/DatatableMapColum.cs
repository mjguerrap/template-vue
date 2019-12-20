using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base
{
    public class DatatableMapColum
{
	private readonly Dictionary<string, string> _armazenador = new Dictionary<string, string>();

	protected Dictionary<string, string> Add(string column, string property)
	{
		_armazenador.Add(column, property);

		return _armazenador;
	}

	public string GetProperty(string column)
	{
		return _armazenador[column];
	}
}
}
