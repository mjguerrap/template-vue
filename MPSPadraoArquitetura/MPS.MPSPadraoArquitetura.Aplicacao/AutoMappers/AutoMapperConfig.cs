using AutoMapper;

namespace MPS.MPSPadraoArquitetura.Aplicacao.AutoMappers
{
    public static class AutoMapperConfig
{
	public static void RegisterMappings()
	{
		Mapper.Initialize(x =>
		{
			x.AddProfile<EntidadeParaViewModel>();
			x.AddProfile<ViewModelParaEntidade>();
		});
	}
}
}
