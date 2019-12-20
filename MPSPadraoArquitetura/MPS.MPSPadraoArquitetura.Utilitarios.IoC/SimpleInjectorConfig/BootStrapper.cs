using SimpleInjector;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.Eventos.Handlers;
using MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Base;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Audit;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Eventos;
using MPS.MPSPadraoArquitetura.Infra.Dados.Contextos;
using MPS.MPSPadraoArquitetura.Infra.Dados.Repositorios.Audit;
using MPS.MPSPadraoArquitetura.Infra.Dados.Repositorios.Eventos;
using MPS.MPSPadraoArquitetura.Infra.Dados.UoW;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Map;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.SimpleInjectorConfig
{
    public static class BootStrapper
{
	public static void RegisterServices(Container container)
	{
		RegistraServicosAplicacao(container);
		RegistraServicosDominio(container);
		RegistraEventosDeDominio(container);
		RegistraServicosRepositorio(container);
		RegistraServicosRepositorioDapper(container);
		RegistraContextos(container);
		RegistraFiltros(container);
		RegistraSharedKernel(container);
	}

	private static void RegistraServicosRepositorioDapper(Container container)
	{

	}


	#region Métodos Auxiliares

	#region Aplicação

	private static void RegistraServicosAplicacao(Container container)
	{
		container.Register<IAuditLogsApp, AuditLogsApp>(Lifestyle.Scoped);
		container.Register<IFotoFuncionarioApp, FotoFuncionarioApp>(Lifestyle.Scoped);
	}

	#endregion Aplicação

	#region Domínio

	private static void RegistraServicosDominio(Container container)
	{

	}

	private static void RegistraEventosDeDominio(Container container)
	{
		container.Register<IDomainNotificationHandler<NotificacoesDominio>, NotificacoesDominioHandler>(Lifestyle.Scoped);
	}

	#endregion Domínio

	#region Repositorio

	private static void RegistraServicosRepositorio(Container container)
	{
		container.Register<IAuditLogsRepositorio, AuditLogsRepositorio>(Lifestyle.Scoped);
		container.Register<INotificacoesDominioRepositorio, NotificacoesDominioRepositorio>(Lifestyle.Scoped);

	}

	#endregion Repositorio

	#region Contextos

	private static void RegistraContextos(Container container)
	{
		container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
		container.Register<Contexto, Contexto>(Lifestyle.Scoped);
	}

	#endregion Contextos

	#region Filtros

	//Registrar MAP da camada MPS.MPSPadraoArquitetura.SharedKernel.DataTables.MAP
	private static void RegistraFiltros(Container container)
	{
		container.Register<AuditLogDataTablesMap>(Lifestyle.Scoped);

	}

	#endregion Filtros

	#region SharedKernel

	private static void RegistraSharedKernel(Container container)
	{
		container.Register<IValidaConfiguracao, ValidaConfiguracao>(Lifestyle.Singleton);
	}

	#endregion SharedKernel
	#endregion Métodos Auxiliares
}
}