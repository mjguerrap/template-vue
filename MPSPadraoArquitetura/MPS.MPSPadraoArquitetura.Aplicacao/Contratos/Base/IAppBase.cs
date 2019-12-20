using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Log;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Base
{
    public interface IAppBase<T>
{
	void Inserir(T viewModel, InformacoesDeLogViewModel informacoesDeLogViewModel);
	void Alterar(T viewModel, InformacoesDeLogViewModel informacoesDeLogViewModel);
	void Excluir(int id, InformacoesDeLogViewModel informacoesDeLogViewModel);
	T ObterPorId(int id);
}
}
