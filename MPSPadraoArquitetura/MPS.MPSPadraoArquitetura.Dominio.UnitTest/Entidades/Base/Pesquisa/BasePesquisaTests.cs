using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPS.MPSPadraoArquitetura.SharedKernel.Enum.Base;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Dominio.Entidades.Base.Pesquisa.Tests
{
    [TestClass()]
public class BasePesquisaTests
{
	static BasePesquisa CriarBasePesquisa()
	{
		return new BasePesquisa()
		{

			Descricao = "Base Pesquisa Unidade Teste",
			Matricula = null,
			NomeFuncionario = "Base Pesquisa Unidade Teste",
			DataInicio = DateTime.Now.AddDays(-1),
			DataFim = DateTime.Now,
			//StatusRegistro = new Base.BaseStatusRegistro() { StatusId = 1},
			StatusRegistroId = StatusRegistroEnum.Inativo.ToByte(),
		};
	}

	[TestMethod()]
	public void ValidarDatasTest()
	{
		var basePesquisa = CriarBasePesquisa();
		Assert.IsTrue(basePesquisa.ValidarDatas());

		//Datas igual com horario diferente
		basePesquisa.DataInicio = basePesquisa.DataFim;
		basePesquisa.DataFim = basePesquisa.DataFim.ToDateTimeDataFim();
		Assert.IsTrue(basePesquisa.ValidarDatas());

		//Datas igual
		basePesquisa.DataInicio = basePesquisa.DataFim;
		Assert.IsFalse(basePesquisa.ValidarDatas());

		//Data inicio nula e data fim data atual
		basePesquisa.DataInicio = null;
		Assert.IsFalse(basePesquisa.ValidarDatas());

		//Datas inicio e fim nulas
		basePesquisa.DataFim = null;
		Assert.IsFalse(basePesquisa.ValidarDatas());

		//Data Fim nula e data inicial data atual
		basePesquisa.DataInicio = DateTime.Now;
		Assert.IsFalse(basePesquisa.ValidarDatas());

		//Data fim menor que data inicio
		basePesquisa.DataFim = DateTime.Now.AddDays(-1);
		Assert.IsFalse(basePesquisa.ValidarDatas());
	}

	[TestMethod()]
	public void ValidarDataInicioTest()
	{
		var basePesquisa = CriarBasePesquisa();
		Assert.IsTrue(basePesquisa.ValidarDataInicio());

		basePesquisa.DataInicio = null;
		Assert.IsFalse(basePesquisa.ValidarDataInicio());

		basePesquisa.DataInicio = DateTime.MinValue;
		Assert.IsFalse(basePesquisa.ValidarDataInicio());
	}

	[TestMethod()]
	public void ValidarDataFimTest()
	{
		var basePesquisa = CriarBasePesquisa();
		Assert.IsTrue(basePesquisa.ValidarDataFim());

		basePesquisa.DataFim = null;
		Assert.IsFalse(basePesquisa.ValidarDataFim());

		basePesquisa.DataFim = DateTime.MinValue;
		Assert.IsFalse(basePesquisa.ValidarDataFim());
	}
}
}