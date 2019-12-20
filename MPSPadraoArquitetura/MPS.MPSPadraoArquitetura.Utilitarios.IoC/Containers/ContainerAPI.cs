using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.Containers
{
    public class ContainerAPI : IContainer
{
	private readonly IDependencyResolver _resolver;

	public ContainerAPI(IDependencyResolver resolver) => _resolver = resolver;

	public T GetService<T>() => (T)_resolver.GetService(typeof(T));

	public object GetService(Type serviceType) => _resolver.GetService(serviceType);

	public IEnumerable<T> GetServices<T>() => (IEnumerable<T>)_resolver.GetServices(typeof(T));

	public IEnumerable<object> GetServices(Type serviceType) => _resolver.GetServices(serviceType);
}
}
