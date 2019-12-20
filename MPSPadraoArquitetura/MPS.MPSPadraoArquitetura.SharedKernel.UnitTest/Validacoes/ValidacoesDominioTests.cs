using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Validacoes.Tests
{
    [TestClass()]
public class ValidacoesDominioTests
{
	[TestMethod()]
	public void IsValidFalseTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValidFalse(false, false, false));
		Assert.IsFalse(ValidacoesDominio.IsValidFalse(false, true, false));
		Assert.IsFalse(ValidacoesDominio.IsValidFalse(true, true, true));
	}

	[TestMethod()]
	public void IsValidTrueTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValidTrue(true, true, true));
		Assert.IsFalse(ValidacoesDominio.IsValidTrue(false, true, false));
		Assert.IsFalse(ValidacoesDominio.IsValidTrue(false, false, false));
	}

	[TestMethod()]
	public void IsValidExistFalseTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValidExistFalse(true, true, true, false));
		Assert.IsFalse(ValidacoesDominio.IsValidExistFalse(true, true, true, true));
		Assert.IsTrue(ValidacoesDominio.IsValidExistFalse(false, false, false, false));
	}

	[TestMethod()]
	public void IsValidExistTrueTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValidExistTrue(false, false, true, false));
		Assert.IsFalse(ValidacoesDominio.IsValidExistTrue(false, false, false, false));
		Assert.IsTrue(ValidacoesDominio.IsValidExistTrue(true, true, true, true));
	}

	[TestMethod()]
	public void ValidarTamanhoStringTest()
	{
		string teste = "teste";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTamanhoString(teste, 3, 10, "Não esta dentro do Tamanho Paramentrizado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTamanhoString(teste, 10, 20, "Não esta dentro do Tamanho Paramentrizado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarStringVaziaOuNulaTest()
	{
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula(string.Empty, "String não pode ser empty", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula(null, "String não pode ser null", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula("", "String não pode ser vazia", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringVaziaOuNula("string", "String não pode ser vazia", this.GetType())));

	}

	[TestMethod()]
	public void ValidarStringsIguaisTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringsIguais("Teste 1", "Teste 1", "Campos de Texto não São iguais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringsIguais("Teste 1", "Teste 2", "Campos de Texto não São iguais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringsIguais("TESTE", "Teste", "Campos de Texto não São iguais", this.GetType())));
	}

	[TestMethod()]
	public void ValidarRegexMatchTest()
	{
		var emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarRegexMatch("www.mps.com.br", emailRegex, "E-mail não é valido", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarRegexMatch("analista@mps.com.br", emailRegex, "E-mail não é valido", this.GetType())));
	}

	[TestMethod()]
	public void ValidarStringSomenteNumeroTest()
	{
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteNumero("teste", "String somente numero", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteNumero("teste 123", "String somente numero", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteNumero("123", "String somente numero", this.GetType())));
	}

	[TestMethod()]
	public void ValidarStringSomenteLetrasTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteLetras("teste", "String somente letra", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteLetras("teste 123", "String somente letra", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSomenteLetras("123", "String somente letra", this.GetType())));
	}

	[TestMethod()]
	public void ValidarTelefoneTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTelefone("1134587821", "String somente numero", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTelefone("11948627814", "String somente numero", this.GetType())));
	}

	[TestMethod()]
	public void ValidarTelefoneMascaraTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTelefoneMascara("(11) 3458-7821", "String somente numero", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarTelefoneMascara("(11) 94862-7814", "String somente numero", this.GetType())));
	}

	[TestMethod()]
	public void ValidarCnpjTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("28.795.045/0001-19", "Validar CNPJ", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("28795045000119", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("28.795.045/0001-18", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("28795045000118", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("00.000.000/0000-00", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("11.111.111/1111-11", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("22.222.222/2222-22", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("33.333.333/3333-33", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("44.444.444/4444-44", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("55.555.555/5555-55", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("66.666.666/6666-66", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("77.777.777/7777-77", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("88.888.888/8888-88", "Validar CNPJ", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCnpj("99.999.999/9999-99", "Validar CNPJ", this.GetType())));
	}

	[TestMethod()]
	public void ValidarCpfTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("764.181.250-37", "Validar CPF", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("76418125037", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("764.181.250-38", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("76418125038", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("000.000.000-00", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("111.111.111-11", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("222.222.222-22", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("333.333.333-33", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("444.444.444-44", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("555.555.555-55", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("666.666.666-66", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("777.777.777-77", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("888.888.888-88", "Validar CPF", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarCpf("999.999.999-99", "Validar CPF", this.GetType())));

	}

	[TestMethod()]
	public void ValidarUrlTest()
	{
		string url = @"https://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"http://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://www.stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"http://www.stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar CPF", this.GetType())));

		url = @"HTTPS://DEV.TJSP.JUS.BR/RHF/MED/";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://qa.tjsp.jus.br/RHF/MED/";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://uat.tjsp.jus.br/RHF/MED/";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://hom.tjsp.jus.br/RHF/MED/";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://www.tjsp.jus.br/RHF/MED/";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));
		url = @"https://www.google.com.br/search?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+maior+que+2054+caracteres+regex+";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"http:/www.stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"https://www.google.com.br/search?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#safe=active&q=validar+url+c%23+Uri.TryCreatesearch?q=validar+cnpj+000000000000000&rlz=1C1CHZL_pt-BRBR722BR722&oq=validar+cnpj+000000000000000&aqs=chrome..69i57.10055j0j7&sourceid=chrome&ie=UTF-8&safe=active#srf";
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

		url = @"www.stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url";
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarUrl(url, "Validar URL", this.GetType())));

	}

	[TestMethod()]
	public void ValidarEmailTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("contato@mps.com.br", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("contato@mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("david.jones@mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("d.j@server1.mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("jones@ms1.mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("j@mps.com9", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("js#internal@mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("j_9@[129.126.118.1]", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("js@mps.com9", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("j.s@server1.mps.com", "Validar E-mail", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("\"j\\\"s\\\"\"@mps.com", "Validar E-mail", this.GetType())));

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("j.@server1.mps.com", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("j..s@mps.com", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("js*@mps.com", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("js@mps..com", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("contato@.com.br", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("contatomps.com.br", "Validar E-mail", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarEmail("@mps.com.br", "Validar E-mail", this.GetType())));

	}

	[TestMethod()]
	public void ValidarObjetoNotNullTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarObjetoNotNull(new Object(), "Validar ObjetoNotNull", this.GetType())));

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarObjetoNotNull(null, "Validar ObjetoNotNull", this.GetType())));
	}

	[TestMethod()]
	public void ValidarObjetoIsNullTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarObjetoIsNull(null, "Validar ObjetoIsNull", this.GetType())));

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarObjetoIsNull(new Object(), "Validar ObjetoIsNull", this.GetType())));
	}

	[TestMethod()]
	public void ValidarIntMaiorQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorQueEsperado(10, 5, "Validar int maior que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorQueEsperado(10, 10, "Validar int maior que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorQueEsperado(10, 15, "Validar int maior que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarInMenoQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorQueEsperado(5, 10, "Validar int menor que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorQueEsperado(10, 10, "Validar int menor que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorQueEsperado(15, 10, "Validar int menor que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarIntMaiorOuIgualQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorOuIgualQueEsperado(10, 5, "Validar int maior ou igual que o esperado", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorOuIgualQueEsperado(10, 10, "Validar int maior ou igual que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMaiorOuIgualQueEsperado(10, 15, "Validar int maior ou igual que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarIntMenorOuIgualQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorOuIgualQueEsperado(5, 10, "Validar int maior ou igual que o esperado", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorOuIgualQueEsperado(10, 10, "Validar int maior ou igual que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarIntMenorOuIgualQueEsperado(15, 10, "Validar int maior ou igual que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarDecimalMaiorQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorQueEsperado(10.1m, 5m, "Validar decimal maior que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorQueEsperado(10.1m, 10.1m, "Validar decimal maior que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorQueEsperado(10.2m, 15.5m, "Validar decimal maior que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarDecimalMaiorOuIgualQueEsperadoTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorOuIgualQueEsperado(10.1m, 5m, "Validar decimal maior que o esperado", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorOuIgualQueEsperado(10.1m, 10.1m, "Validar decimal maior que o esperado", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDecimalMaiorOuIgualQueEsperado(10.2m, 15.5m, "Validar decimal maior que o esperado", this.GetType())));
	}

	[TestMethod()]
	public void ValidarDataTest()
	{
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarData("2017-07-21", "Validar Data", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarData("21-07-2017", "Validar Data", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarData("21/07/2017", "Validar Data", this.GetType())));

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarData("07/21/2017", "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarData("2017-21-07", "Validar Data", this.GetType())));
	}

	[TestMethod()]
	public void ValidarDataMinimaTest()
	{
		string data = "21/07/2017";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataMinima(data.ToDateTime(), "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataMinima(null, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataMinima(DateTime.MinValue, "Validar Data", this.GetType())));
	}

	[TestMethod()]
	public void ValidarDataInicioDataFimTest()
	{
		string dataInicio = "01-07-2017";
		string dataFim = "21-07-2017";

		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataInicio.ToDateTime(), dataFim.ToDateTime().ToDateTimeDataFim(), "Validar Data", this.GetType())));
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataFim.ToDateTime(), dataFim.ToDateTime().ToDateTimeDataFim(), "Validar Data", this.GetType())));

		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataFim.ToDateTime(), dataFim.ToDateTime(), "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(DateTime.MinValue, DateTime.MaxValue, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(DateTime.MaxValue, DateTime.MinValue, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(null, null, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(null, dataFim.ToDateTime(), "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataInicio.ToDateTime(), null, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(DateTime.MinValue, dataFim.ToDateTime(), "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataInicio.ToDateTime(), DateTime.MinValue, "Validar Data", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarDataInicioDataFim(dataInicio.ToDateTime(), DateTime.MaxValue, "Validar Data", this.GetType())));

	}

	[TestMethod()]
	public void ValidarStringSomenteEspacoEspeciaisTest()
	{
		string Descricao = "Nomes";
		Assert.IsTrue(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSemEspacoEspeciais(Descricao, "Validar String sem caracteres especiais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSemEspacoEspeciais("Nome Espaco", "Validar String sem caracteres especiais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSemEspacoEspeciais("Nome_Espaço", "Validar String sem caracteres especiais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSemEspacoEspeciais("Nomefunção", "Validar String sem caracteres especiais", this.GetType())));
		Assert.IsFalse(ValidacoesDominio.IsValid(ValidacoesDominio.ValidarStringSemEspacoEspeciais("Nome@", "Validar String sem caracteres especiais", this.GetType())));

	}
}
}