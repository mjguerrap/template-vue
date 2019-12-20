using System;
using System.Collections.Generic;
using System.Configuration;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class Constantes
{
	public static readonly int UsuarioMPS = int.Parse(ConfigurationManager.AppSettings["UsuarioMPS"]);
	public static readonly int Empresa = 1;
	public static readonly int Filial = 1;
}
}
