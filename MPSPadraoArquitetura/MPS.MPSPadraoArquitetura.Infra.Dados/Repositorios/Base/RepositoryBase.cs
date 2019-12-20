using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Base;
using MPS.MPSPadraoArquitetura.Infra.Dados.Contextos;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes.Handlers;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Entidades;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Repositorios.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
	private Contexto _contexto;

	public Contexto Contexto { get { return _contexto; } }

	/// <summary>
	/// Método para intaciar o contexto Base
	/// </summary>
	/// <param name="contexto"></param>
	protected void Initialize(Contexto contexto)
	{
		_contexto = contexto;
	}

	#region  SÍNCRONOS
	public virtual void Inserir(T entity)
	{
		_contexto.Set<T>().Add(entity);
	}

	public virtual void Alterar(T entity)
	{
		_contexto.Entry(entity).State = EntityState.Modified;
	}

	public virtual void Excluir(T entity)
	{
		_contexto.Set<T>().Remove(entity);
	}

	public virtual T ObterPorId(int id)
	{
		return _contexto.Set<T>().Find(id);
	}

	public IEnumerable<T> Selecionar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
	{
		var query = _contexto.Set<T>().AsQueryable();

		if (includes != null)
		{
			query = includes.Aggregate(query, (current, include) => current.Include(include));
		}


		return query.Where(predicate);
	}

	public IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes)
	{
		var query = _contexto.Set<T>().AsQueryable();
		if (includes != null)
		{
			query = includes.Aggregate(query, (current, include) => current.Include(include));
		}


		return query;
	}

	public int Salvar(string usuario)
	{
		return _contexto.Salvar(usuario);
	}

	public void Commit()
	{
		_contexto.SaveChanges();
	}
	#endregion SÍNCRONOS

	#region ASSÍNCRONOs
	public virtual async Task<bool> InserirAsync(T entidade)
	{
		_contexto.Set<T>().Add(entidade);
		return await CommitAsync().ConfigureAwait(false) > 0;
	}

	public virtual async Task<bool> AlterarAsync(T entity)
	{
		_contexto.Entry(entity).State = EntityState.Modified;
		return await CommitAsync().ConfigureAwait(false) > 0;
	}

	public virtual async Task<bool> ExcluirAsync(T entity)
	{
		_contexto.Set<T>().Remove(entity);
		return await CommitAsync().ConfigureAwait(false) > 0;
	}

	public virtual async Task<T> ObterPorIdAsync(int id)
	{
		return await _contexto.Set<T>().FindAsync(id).ConfigureAwait(false);
	}

	public virtual async Task<int> SalvarAsync(string usuario)
	{
		return await _contexto.SaveChangesAsync(usuario).ConfigureAwait(false);
	}

	public async Task<int> CommitAsync()
	{
		return await _contexto.SaveChangesAsync().ConfigureAwait(false);
	}
	#endregion ASSÍNCRONOs

}
}
