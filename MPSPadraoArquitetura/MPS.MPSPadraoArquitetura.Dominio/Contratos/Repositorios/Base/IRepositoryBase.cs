using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Base
{
    public interface IRepositoryBase<T>
{
	void Inserir(T entity);
	void Alterar(T entity);
	void Excluir(T entity);
	T ObterPorId(int id);
	int Salvar(string usuario);

	//Os Metodos async deverão ser implementado de acordo com sua necessidade de utilização de processos paralelos
	Task<bool> InserirAsync(T entidade);
	Task<bool> AlterarAsync(T entity);
	Task<bool> ExcluirAsync(T entity);
	Task<T> ObterPorIdAsync(int id);
	Task<int> SalvarAsync(string usuario);
}
}
