using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Professor.AtualizarProfessor
{
    public class AtualizarProfessorHandler : Notifiable,
        IRequestHandler<AtualizarProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public AtualizarProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(AtualizarProfessorRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AtualizarProfessorHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O PROFESSOR JÁ ESTA CADASTRADO
            var professor = _repositoryProfessor.ObterPorId(request.Id);
            if (professor==null)
            {
                AddNotification("AtualizarProfessorHandler", "Professor Não Localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT PROFESSOR
            professor.Atualizar(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(professor);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryProfessor.Atualizar(professor);

            return Task.FromResult(new CommandResponse(new AtualizarProfessorResponse(
              professor.Id, professor.Cpf, professor.Nome, "Professor Atualizado Com Sucesso"), this));
        }
    }
}
