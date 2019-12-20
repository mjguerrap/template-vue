using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig;

[assembly: OwinStartup(typeof(MPS.MPSPadraoArquitetura.Api.Startup))]
namespace MPS.MPSPadraoArquitetura.Api
{
    public static class Startup
{
	public static void Configuration(IAppBuilder app)
	{
		using (var config = new HttpConfiguration())
		{
			SimpleInjectorWebApiInitializer.Initialize(config);
			ConfigureWebApi(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}
	}

	public static void ConfigureWebApi(HttpConfiguration config)
	{
		var formatters = config.Formatters;
		formatters.Remove(formatters.XmlFormatter);

		var jsonSettings = formatters.JsonFormatter.SerializerSettings;
		jsonSettings.Formatting = Formatting.Indented;
		jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

		config.MapHttpAttributeRoutes();
		config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
	}
}
}
