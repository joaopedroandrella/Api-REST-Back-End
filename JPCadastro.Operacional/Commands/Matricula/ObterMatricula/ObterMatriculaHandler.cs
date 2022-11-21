using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Matricula.ObterMatricula
{
    public class ObterMatriculaHandler : Notifiable,
        IRequestHandler<ObterMatriculaRequest, CommandResponse>
    {
        private readonly IRepositoryMatricula _repositoryMatricula;

        public ObterMatriculaHandler(IRepositoryMatricula repositoryMatricula)
        {
            _repositoryMatricula=repositoryMatricula;
        }

        public Task<CommandResponse> Handle(ObterMatriculaRequest request,
            CancellationToken cancellationToken)
        {
            if (request==null)
            {
                AddNotification("ObterMatriculaHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O MATRICULA JÁ ESTA CADASTRADA
            var Matricula = _repositoryMatricula.ObterPorId(request.Id);

            if (Matricula==null)
            {
                AddNotification("ObterMatriculaHandler", "Matricula não localizada");
                return Task.FromResult(new CommandResponse(this));
            }

            return Task.FromResult(new CommandResponse(new ObterMatriculaResponse
            {
                Id = Matricula.Id,
                CursoId = Matricula.CursoId,
                AlunoId = Matricula.AlunoId,
                Status = Matricula.Status,  
            }, this));
        }
    }
}
