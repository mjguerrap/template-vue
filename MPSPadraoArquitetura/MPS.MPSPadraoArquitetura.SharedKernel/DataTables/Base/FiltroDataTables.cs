using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Web;

namespace MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base
{
    public sealed class FiltroDataTables
{
	public int Draw { get; private set; }
	public int Start { get; private set; }
	public int Length { get; private set; }
	public string Search { get; private set; }
	public string Column { get; private set; }
	public string SortOrder { get; private set; }

	public FiltroDataTables(int draw, int start, int length, string search, string column, string sortOrder)
	{
		Draw = draw;
		Start = start;
		Length = length;
		Search = search;
		Column = column;
		SortOrder = sortOrder;
	}

	public FiltroDataTables(HttpContext request)
	{
		if (request != null)
		{
			Draw = Convert.ToInt32(request.Request.Query["draw"]);
			Start = Convert.ToInt32(request.Request.Query["start"]);
			Length = Convert.ToInt32(request.Request.Query["length"]);
			Search = request.Request.Query["search[value]"];
			Column = request.Request.Query["columns[" + request.Request.Query["order[0][column]"] + "][data]"];
			SortOrder = request.Request.Query["order[0][dir]"];
		}
	}
}
}
