using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Validacoes.Base.Tests
{
    [TestClass()]
public class BaseValidacaoTests
{
	[TestMethod()]
	public void ValidarUsuarioTest()
	{
		Assert.IsTrue(BaseValidacao.ValidarUsuario("123456", this.GetType()));
		Assert.IsFalse(BaseValidacao.ValidarUsuario("12345", this.GetType()));
		Assert.IsFalse(BaseValidacao.ValidarUsuario("T123456", this.GetType()));
		Assert.IsFalse(BaseValidacao.ValidarUsuario("12345678901", this.GetType()));
	}

	[TestMethod()]
	public void ValidarDataTest()
	{
		DateTime? data = DateTime.Now;
		Assert.IsTrue(BaseValidacao.ValidarData(data, this.GetType()));

		data = null;
		Assert.IsFalse(BaseValidacao.ValidarData(data, this.GetType()));

		data = DateTime.MinValue;
		Assert.IsFalse(BaseValidacao.ValidarData(data, this.GetType()));

	}

	[TestMethod()]
	public void ValidarStatusRegistroTest()
	{
		Assert.IsTrue(BaseValidacao.ValidarStatusRegistro(0, this.GetType()));
		Assert.IsTrue(BaseValidacao.ValidarStatusRegistro(3, this.GetType()));
		Assert.IsFalse(BaseValidacao.ValidarStatusRegistro(10, this.GetType()));
	}
}
}