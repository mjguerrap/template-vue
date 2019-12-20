using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Eventos;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Eventos.Notificacoes;
using MPS.MPSPadraoArquitetura.Infra.Dados.Contextos;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.Repositorios.Eventos
{
    /// <summary>
    /// repositório de notificações de domínio com contexto separado
    /// </summary>
    public class NotificacoesDominioRepositorio : INotificacoesDominioRepositorio
{
	/// <summary>
	/// contexto criado internamente em vez de injetado:
	/// Se estamos usando o context per request e ocorrer uma exception ao usar o context principal, este estará em um estado impossível de salvar
	/// Mesmo executando-se um rollback, o contexto carrega em memória as mudanças de alteração em cada entidade, e a única maneira de descartar isso
	/// é criando um contexto novo
	/// </summary>
	public NotificacoesDominioRepositorio()
	{

	}

	public void Inserir(NotificacoesDominio entity)
	{
		using (Contexto _contexto = new Contexto())
		{
			_contexto.NotificacoesDominio.Add(entity);
			_contexto.SaveChanges();
		}
	}

}
}