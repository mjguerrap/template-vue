using AutoMapper;
using MPS.MPSPadraoArquitetura.Aplicacao.Contratos.Audit;
using MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Base;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo;
using MPS.MPSPadraoArquitetura.Aplicacao.ViewModel.Areas.Administrativo.Pesquisa;
using MPS.MPSPadraoArquitetura.Dominio.Contratos.Repositorios.Audit;
using MPS.MPSPadraoArquitetura.Infra.Dados.UoW;
using System.Collections.Generic;
using TrackerEnabledDbContext.Common.Models;

namespace MPS.MPSPadraoArquitetura.Aplicacao.Servicos.Audit
{
    public class AuditLogsApp : ApplicationService, IAuditLogsApp
    {
        private readonly IAuditLogsRepositorio _auditLogRepositorio;

        public AuditLogsApp(IUnitOfWork unitOfWork, IAuditLogsRepositorio auditLogsRepositorio) : base(unitOfWork)
        {
            _auditLogRepositorio = auditLogsRepositorio;
        }

        public IEnumerable<AuditLogViewModel> Selecionar(PesquisaAuditLogViewModel viewModel, out int total)
        {
            //TODO: (Guerra) Refatorar isso aqui
            List<AuditLogViewModel> listaRetorno = new List<AuditLogViewModel>();
            total = 100;
            return listaRetorno;
        }

        public IEnumerable<AuditLogMetadataViewModel> SelecionarMetadata(long id)
        {
            //TODO: (Guerra) Refatorar isso aqui
            List<LogMetadata> lista = new List<LogMetadata>(); // _auditLogRepositorio.SelecionarMetadata(id).ToList();
            return Mapper.Map(lista, new List<AuditLogMetadataViewModel>());
        }

        public IEnumerable<string> SelecionarClassesLog()
        {
            //TODO: (Guerra) Refatorar isso aqui
            return new List<string>(); // _auditLogRepositorio.SelecionarClassesDoLog().ToList();
        }
    }
}
