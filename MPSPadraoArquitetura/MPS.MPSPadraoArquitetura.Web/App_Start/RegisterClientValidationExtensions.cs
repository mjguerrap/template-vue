using DataAnnotationsExtensions.ClientValidation;
using MPS.MPSPadraoArquitetura.Web.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RegisterClientValidationExtensions), "Start")]

namespace MPS.MPSPadraoArquitetura.Web.App_Start {

    public static class RegisterClientValidationExtensions
{

	public static void Start()
	{
		DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
	}

}

}