using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base;

namespace MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Map
{
    public class AuditLogDataTablesMap : DatatableMapColum
{
	/// <summary>
	/// Add("{Coluna_DataTable}", "{Propriedade_Entidade}");
	/// </summary>
	public AuditLogDataTablesMap()
	{
		Add("UserName", "UserName");
		Add("EventDateUTC", "EventDateUTC");
		Add("EventType", "EventType");
		Add("TypeFullName", "TypeFullName");
	}

}
}
