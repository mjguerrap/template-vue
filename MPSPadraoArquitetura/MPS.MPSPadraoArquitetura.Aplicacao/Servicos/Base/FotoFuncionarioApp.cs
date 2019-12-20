using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.FuncionarioService;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Base
{
    public class FotoFuncionarioApp : IFotoFuncionarioApp
{
	public byte[] ObterFotoFuncionario(int matricula)
	{
		byte[] retorno = null;

		if (matricula != Constantes.UsuarioMPS)
		{
			BaseEntrada baseEntrada = new BaseEntrada()
			{
				Empresa = Constantes.Empresa,
				Filial = Constantes.Filial,
				EmpresaSHFCod = Constantes.Empresa,
				Matricula = matricula
			};

			using (FuncionarioServiceClient funcionarioService = new FuncionarioServiceClient())
			{
				BaseRetornoObjetoOfFotoFuncionarioJCxYsfas retornoWcf = null;
				retornoWcf = funcionarioService.ObterFotoPorMatricula(baseEntrada);
				if (retornoWcf != null && retornoWcf.Resultado)
				{
					retorno = retornoWcf.Objeto.Foto;
				}
			}
		}

		return retorno;
	}

}
}
