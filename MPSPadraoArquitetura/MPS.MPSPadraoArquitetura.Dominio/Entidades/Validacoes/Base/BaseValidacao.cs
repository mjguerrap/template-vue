using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Validacoes.Base
{
    public static class BaseValidacao
{


	public static bool ValidarUsuario(string usuario, Type type)
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula(usuario, "Usuário alteração não informado", type),
			ValidacoesDominio.ValidarTamanhoString(usuario, 6, 10, "Usuário informado não corresponde ao tamano da Matricula", type),
			ValidacoesDominio.ValidarStringSomenteNumero(usuario, "Usuário informado somente números na Matricula", type));
	}
	public static bool ValidarData(DateTime? data, Type type)
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataMinima(data, "Data do alteração invalida", type));
	}
	public static bool ValidarStatusRegistro(byte statusRegistroId, Type type)
	{
		return ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorOuIgualQueEsperado(statusRegistroId, 0, "Usuário alteração não informado", type),
			ValidacoesDominio.ValidarIntMenorOuIgualQueEsperado(statusRegistroId, 3, "Usuário informado não corresponde ao tamanho da Matricula", type));
	}
}
}
