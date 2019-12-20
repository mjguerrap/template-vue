using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using TrackerEnabledDbContext;
using MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Base;
using MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Audit;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.Infra.Dados.Mapeamentos.Eventos;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Contextos
{
    public class Contexto : TrackerContext
{
	public Contexto() : base("Name=DefaultConnection")
	{
		Configuration.LazyLoadingEnabled = false;
		Configuration.ProxyCreationEnabled = false;
	}

	#region Propriedades do Sistema

	public DbSet<NotificacoesDominio> NotificacoesDominio { get; set; }

	//public DbSet<{NomeEntidade}> {NomeEntidade} { get; set; }

	#endregion Propriedades do Sistema

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		ConfigureDefault(modelBuilder);
		ConfigureLogs(modelBuilder);
		ConfigureMaps(modelBuilder);

		//Método responsável para mapear as entidades que terão LOG na aplicação.
		MapeamentoEntidadesAuditlog();
	}

	private static void ConfigureDefault(DbModelBuilder modelBuilder)
	{
		modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

		modelBuilder.Properties()
			.Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
			.Configure(p => p.IsKey());
		modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar").HasMaxLength(50));
	}

	private static void ConfigureLogs(DbModelBuilder modelBuilder)
	{
		modelBuilder.Configurations.Add(new AuditLogsMap());
		modelBuilder.Configurations.Add(new AuditLogsDetailsMap());
		modelBuilder.Configurations.Add(new AuditMetaDataMap());
	}

	private static void ConfigureMaps(DbModelBuilder modelBuilder)
	{
		modelBuilder.Configurations.Add(new BaseStatusRegistroMap());
		modelBuilder.Configurations.Add(new NotificacoesDominioMap());

	}

	public static void MapeamentoEntidadesAuditlog()
	{
		/*

        Se a {NomeEntidade}Map estiver usando a BaseMap, então todas as propriedades da entidade terão logs por padrão.
        Abaixo segue exemplos de como utilizar o AuditLog caso a entidade não use o BaseMap.

        OBS: Para maiores informações: https://github.com/bilal-fazlani/tracker-enabled-dbcontext/wiki/

        */

		//Loga todas as propriedades da Entidade
		//EntityTracker.TrackAllProperties<{NomeEntidade}>();

		//Informa que a entidade será logada, mas as propriedades X não será logada.
		//EntityTracker.TrackAllProperties<{NomeEntidade}>().Except(x => x.{NomePropriedade});

		//Informa que a entidade será logada, mas as propriedades X e Y não serão logadas.
		//EntityTracker.TrackAllProperties<{NomeEntidade}>().Except(x => x.{NomePropriedade}).And(x => x.{NomePropriedade});

		//Desabilito o LOG da Entidade por completo
		//EntityTracker.OverrideTracking<{NomeEntidade}>().Disable();

		//Habilitar o LOG da Entidade que teria sido desabilitada
		//EntityTracker.OverrideTracking<{NomeEntidade}>().Enable();
	}

	//Criar Metoso Async para salvar com o usuário
	public int Salvar(string usuario)
	{
		try
		{
			return base.SaveChanges(usuario);
		}
		catch (DbUpdateException due) ///<summary>Quando algum erro diferente foi apresentado e for possivel ser trantado incluir a tratativa</summary>
		{
			//armazena a mensagem de erro e as mensagens das duas exceptions interiores
			string mensagens = due.Message + " "
				+ due.InnerException?.Message + " "
				+ due.InnerException?.InnerException?.Message;

			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Erro de atualização: " + mensagens, null, true));
		}
		catch (DbEntityValidationException dve)
		{
			// Retrieve the error messages as a list of strings.
			var errorMessages = dve.EntityValidationErrors
					.SelectMany(x => x.ValidationErrors)
					.Select(x => x.ErrorMessage);

			// Join the list to a single string.
			var fullErrorMessage = string.Join("; ", errorMessages);

			// Combine the original exception message with the new one.
			var exceptionMessage = string.Concat(dve.Message, " Erros de Validação: ", fullErrorMessage);

			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", exceptionMessage, null, true));

		}
		catch (InvalidOperationException ioe)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Ocorreu um erro devido a uma operação inválida: " + ioe.Message, null, true));
		}
		catch (Exception ex)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Ocorreu um erro inesperado: " + ex.Message, null, true));

			//usar thorw para preservar a stack e gravar o log correto no elmah
			throw;
		}

		return 0;

	}

	public override Task<int> SaveChangesAsync(string userName)
	{
		try
		{
			return base.SaveChangesAsync(userName);
		}
		catch (DbUpdateException due) ///<summary>Quando algum erro diferente foi apresentado e for possivel ser trantado incluir a tratativa</summary>
		{
			//armazena a mensagem de erro e as mensagens das duas exceptions interiores
			string mensagens = due.Message + " "
				+ due.InnerException?.Message + " "
				+ due.InnerException?.InnerException?.Message;

			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Erro de atualização: " + mensagens, null, true));
		}
		catch (DbEntityValidationException dve)
		{
			// Retrieve the error messages as a list of strings.
			var errorMessages = dve.EntityValidationErrors
					.SelectMany(x => x.ValidationErrors)
					.Select(x => x.ErrorMessage);

			// Join the list to a single string.
			var fullErrorMessage = string.Join("; ", errorMessages);

			// Combine the original exception message with the new one.
			var exceptionMessage = string.Concat(dve.Message, " Erros de Validação: ", fullErrorMessage);

			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", exceptionMessage, null, true));

		}
		catch (InvalidOperationException ioe)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Ocorreu um erro devido a uma operação inválida: " + ioe.Message, null, true));
		}
		catch (Exception ex)
		{
			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", "Ocorreu um erro inesperado: " + ex.Message, null, true));

			//usar thorw para preservar a stack e gravar o log correto no elmah
			throw;
		}

		return Task.FromResult(0);
	}

}
}
