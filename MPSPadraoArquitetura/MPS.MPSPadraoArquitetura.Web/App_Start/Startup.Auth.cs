using Owin;
using System;
using System.Configuration;
using MPS.SSO.Owin.SignIn;

namespace MPS.MPSPadraoArquitetura.Web
{
    public partial class Startup
{
	public void ConfigureAuth(IAppBuilder app)
	{
		app.UseSingleSignOnAuthentication(new SingleSignOnAuthenticationOptions(
			ConfigurationManager.AppSettings["FederationMetadata"],
			 ConfigurationManager.AppSettings["Realm"],
			 TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["SlidingExpirationTime"]))
			));
	}
}
}