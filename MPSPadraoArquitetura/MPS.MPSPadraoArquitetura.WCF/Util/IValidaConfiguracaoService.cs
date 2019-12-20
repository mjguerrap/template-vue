using MPS.MPSPadraoArquitetura.SharedKernel.Base.Retorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MPS.MPSPadraoArquitetura.WCF.Util
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IValidaConfiguracaoService" in both code and config file together.
    [ServiceContract]
public interface IValidaConfiguracaoService
{
	[WebGet(UriTemplate = "VersaoSistema/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
	[OperationContract]
	BaseRetorno VersaoSistema();

	[WebGet(UriTemplate = "ValidarConection/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
	[OperationContract]
	BaseRetorno ValidarConection(string ambiente);
}
}
