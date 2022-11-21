using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Professor.RemoverProfessor
{
    public class RemoverProfessorHandler : Notifiable,
        IRequestHandler<RemoverProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public RemoverProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(RemoverProfessorRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("RemoverProfessorHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O PROFESSOR JÁ ESTA CADASTRADO
            var professor = _repositoryProfessor.ObterPorId(request.Id);
            if (professor==null)
            {
                AddNotification("RemoverProfessorHandler", "Professor não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryProfessor.Remover(professor);

            return Task.FromResult(new CommandResponse(new RemoverProfessorResponse(
                "Professor Removido Com Sucesso"), this));
        }
    }
}
