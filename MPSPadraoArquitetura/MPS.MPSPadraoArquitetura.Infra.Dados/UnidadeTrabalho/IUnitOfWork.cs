using System;

namespace MPS.MPSPadraoArquitetura.Infra.Dados.UoW
{
    public interface IUnitOfWork : IDisposable
{
	void BeginTrasaction();

	void Commit();

	void Rollback();

	void Salvar(string usuario);

	void RequestLogMetaData(string ip, string browser, string sitemaOperacional, string dispositivo, string usuarioLogado, string usuarioLogadoMatricula);
}
}
