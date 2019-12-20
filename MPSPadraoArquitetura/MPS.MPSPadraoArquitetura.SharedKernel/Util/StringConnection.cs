using System.Configuration;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class StringConnection
{
	public static string Connection()
	{
		return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
	}
}
}
