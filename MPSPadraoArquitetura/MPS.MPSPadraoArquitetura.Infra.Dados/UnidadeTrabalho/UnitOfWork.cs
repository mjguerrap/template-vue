using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using MPS.MPSPadraoArquitetura.Infra.Dados.Contextos;
using MPS.MPSPadraoArquitetura.SharedKernel.Validacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.UoW
{
    public class UnitOfWork : IUnitOfWork
{
	private readonly Contexto _dbContext;
	private DbContextTransaction _transaction;
	private bool _disposed;

	public UnitOfWork(Contexto context)
	{
		_dbContext = context;
	}

	public void BeginTrasaction()
	{
		_transaction = _dbContext.Database.BeginTransaction();
	}

	public void Commit()
	{
		_transaction.Commit();
	}

	public void Rollback()
	{
		_transaction.Rollback();
	}

	public void RequestLogMetaData(string ip, string browser, string sitemaOperacional, string dispositivo, string usuarioLogado, string usuarioLogadoMatricula)
	{
		_dbContext.ConfigureMetadata(metadata =>
		{
			metadata.IP = ip;
			metadata.Browser = browser;
			metadata.SitemaOperacional = sitemaOperacional;
			metadata.Dispositivo = dispositivo;
			metadata.UsuarioLogado = usuarioLogado;
			metadata.UsuarioLogadoMatricula = usuarioLogadoMatricula;
		});
	}

	public void Salvar(string usuario)
	{
		try
		{
			_dbContext.SaveChanges(usuario);
		}
		catch (DbEntityValidationException ex)
		{
			// Retrieve the error messages as a list of strings.
			var errorMessages = ex.EntityValidationErrors
					.SelectMany(x => x.ValidationErrors)
					.Select(x => x.ErrorMessage);

			// Join the list to a single string.
			var fullErrorMessage = string.Join("; ", errorMessages);

			// Combine the original exception message with the new one.
			var exceptionMessage = string.Concat(ex.Message, " Erros de Validação: ", fullErrorMessage);

			// Throw a new DbEntityValidationException with the improved exception message.
			ValidacoesDominio.IsValid(new NotificacoesDominio("BaseSalvar", exceptionMessage, null, true));
			throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}


		if (disposing)
		{
			if (!Equals(_dbContext, null))
			{
				_dbContext.Dispose();
			}
		}

		_disposed = true;
	}
}
}
