using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.ListarCurso
{
    public class ListarCursoHandler : Notifiable,
        IRequestHandler<ListarCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;

        public ListarCursoHandler(IRepositoryCurso repositoryCurso)
        {
            _repositoryCurso=repositoryCurso;
        }
    
        public Task<CommandResponse> Handle(ListarCursoRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O CURSO JÁ ESTA CADASTRADO
            var colecaoCurso = _repositoryCurso.ListarSemRastreamento(p => p.Professor);

            return Task.FromResult(new CommandResponse(colecaoCurso.Select(p => new ListarCursoResponse
            {
                Id= p.Id,
                Nome= p.Nome,
                Periodo=  p.Periodo == Periodo.Manha ? "Manha" 
                                       : p.Periodo == Periodo.Tarde ? "Tarde" 
                                       : p.Periodo == Periodo.Noite ? "Noite" : "Integral",
                ProfessorId= p.ProfessorId,
                ProfessorNome=p.Professor?.Nome
            }), this));
        }
    }
}
