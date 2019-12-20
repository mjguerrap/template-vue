using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Enum.Audit
{
    [Description(description: "Operação")]
public enum OperacaoEnum : byte
{
	//Enum para ser o mesmo do "EventType" usado pelo TrackerEnabledDbContext.Common

	[Description("Inserção")]
	Added = 0,
	[Description("Exclusão")]
	Deleted = 1,
	[Description("Alteração")]
	Modified = 2,
	[Description("Exclusão Lógica")]
	SoftDeleted = 3,
	[Description("Retorno Exclusão Lógica")]
	UnDeleted = 4
}
}
