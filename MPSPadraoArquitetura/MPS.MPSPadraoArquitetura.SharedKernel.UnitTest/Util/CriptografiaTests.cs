using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util.Tests
{
    [TestClass()]
public class CriptografiaTests
{
	readonly string chaveCriptografia = "TesteUnitario";
	readonly string texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris scelerisque iaculis ultricies.";
	private string textoCriptografado;
	private string textoDescriptografado;

	readonly int id = 10;
	private int idCriptografado;
	private int idDescriptografado;


	private void Criptografa()
	{
		textoCriptografado = Criptografia.Criptografar(chaveCriptografia, texto);
	}
	private void CriptografaId()
	{
		idCriptografado = Criptografia.CriptografarIdsParaUrl(id);
	}

	[TestMethod()]
	public void CriptografarTest()
	{
		Criptografa();
		Assert.IsFalse(textoCriptografado.Equals(texto));
	}

	[TestMethod()]
	public void DecriptografarTest()
	{
		Criptografa();
		textoDescriptografado = Criptografia.Decriptografar(chaveCriptografia, textoCriptografado);
		Assert.IsTrue(textoDescriptografado.Equals(texto));

		textoDescriptografado = Criptografia.Decriptografar("Teste", textoCriptografado);
		Assert.IsFalse(textoDescriptografado.Equals(texto));

		textoDescriptografado = Criptografia.Decriptografar(chaveCriptografia, textoCriptografado + "1");
		Assert.IsFalse(textoDescriptografado.Equals(texto));
	}

	[TestMethod()]
	public void CriptografarIdsParaURLTest()
	{
		CriptografaId();
		Assert.IsFalse(idCriptografado.Equals(id));
	}

	[TestMethod()]
	public void DescriptografarIdsParaURLTest()
	{
		CriptografaId();
		idDescriptografado = Criptografia.DescriptografarIdsParaUrl(idCriptografado);
		Assert.IsTrue(idDescriptografado.Equals(id));

		idDescriptografado = Criptografia.DescriptografarIdsParaUrl(11);
		Assert.IsFalse(idDescriptografado.Equals(id));
	}
}
}