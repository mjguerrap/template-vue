using MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos
{
    public interface IValidaConfiguracao
{
	BaseRetorno VersaoSistema();
	BaseRetorno ValidarConection(string ambiente);
}
}
