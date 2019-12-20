using System;
using System.Collections.Generic;
using MPS.MPSPadraoArquitetura.SharedKernel.EventosDominio.Contratos;
using SimpleInjector;

namespace MPS.MPSPadraoArquitetura.Utilitarios.IoC.Containers
{
    public class ContainerWCF : IContainer
{
	private readonly Container _container;
	public ContainerWCF(Container container) => _container = container;

	public T GetService<T>() => (T)_container.GetInstance(typeof(T));

	public object GetService(Type serviceType) => _container.GetInstance(serviceType);

	public IEnumerable<T> GetServices<T>() => (IEnumerable<T>)_container.GetAllInstances(typeof(T));

	public IEnumerable<object> GetServices(Type serviceType) => _container.GetAllInstances(serviceType);

}
}
