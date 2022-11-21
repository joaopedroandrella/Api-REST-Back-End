using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Matricula.RemoverMatricula
{
    public class RemoverMatriculaHandler : Notifiable,
        IRequestHandler<RemoverMatriculaRequest, CommandResponse>
    {
        private readonly IRepositoryMatricula _repositoryMatricula;

        public RemoverMatriculaHandler(IRepositoryMatricula repositoryMatricula)
        {
            _repositoryMatricula=repositoryMatricula;
        }

        public Task<CommandResponse> Handle(RemoverMatriculaRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("RemoverMatriculaHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            var Matricula = _repositoryMatricula.ObterPorId(request.Id);
            if (Matricula==null)
            {
                AddNotification("RemoverMatriculaHandler", "Matricula não localizada");
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryMatricula.Remover(Matricula);

            return Task.FromResult(new CommandResponse(new RemoverMatriculaResponse(
                "Matricula Removida Com Sucesso"), this));
        }
    }
}
