using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.ObterCurso
{
    public class ObterCursoHandler : Notifiable,
        IRequestHandler<ObterCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;

        public ObterCursoHandler(IRepositoryCurso repositoryCurso)
        {
            _repositoryCurso=repositoryCurso;
        }

        public Task<CommandResponse> Handle(ObterCursoRequest request,
            CancellationToken cancellationToken)
        {
            if (request==null)
            {
                AddNotification("ObterCursoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O CURSO JÁ ESTA CADASTRADO
            var curso = _repositoryCurso.ObterPorId(request.Id);

            if (curso==null)
            {
                AddNotification("ObterCursoHandler", "Curso não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            return Task.FromResult(new CommandResponse(new ObterCursoResponse
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Periodo = curso.Periodo,
                ProfessorId = curso.ProfessorId
            }, this));
        }
    }
}
