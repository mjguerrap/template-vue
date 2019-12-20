using System;
using System.Collections.Generic;
using System.Linq;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base
{

    public enum DirecaoOrdenacaoDataTableEnum
{
	Asc, Desc
}

public class ColunaOrdenacaoDataTable
{
	public string Column { get; set; }
	public DirecaoOrdenacaoDataTableEnum Dir { get; set; }
}

public class PesquisaDataTable
{
	public string Value { get; set; }
	public string Regex { get; set; }
}

public class ColunasDataTable
{
	public string Data { get; set; }
	public string Name { get; set; }
	public bool Searchable { get; set; }
	public bool Orderable { get; set; }
	public PesquisaDataTable Search { get; set; }
}

public class ParametrosDataTables
{
	public int Draw { get; set; }
	public int Start { get; set; }
	public PesquisaDataTable Search { get; set; }
	public IList<ColunaOrdenacaoDataTable> Order { get; set; }
	public IList<ColunasDataTable> Columns { get; set; }
	public int Length { get; set; }
	public int Total { get; set; }

	public int GetIndiceColunaOrdenada()
	{
		return Order.First().Column.ToInt();
	}

	public string GetNomeColunaOrdenada()
	{
		return Columns[this.GetIndiceColunaOrdenada()].Data;
	}

	public string GetDirecaoColunaOrdenada()
	{
		return Order?.First().Dir.ToString() ?? DirecaoOrdenacaoDataTableEnum.Asc.ToString();
	}
}
}
