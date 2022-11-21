using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Aluno.AdicionarProfessor;
using JPCadastro.Operacional.Entities.Professor;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Professor.AdicionarProfessor
{
    public class AdicionarProfessorHandler : Notifiable,
        IRequestHandler<AdicionarProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public AdicionarProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(AdicionarProfessorRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarProfessorHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT PROFESSOR
           var professor = new ProfessorEntity(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(professor);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryProfessor.Adicionar(professor);

            return Task.FromResult(new CommandResponse(new AdicionarProfessorResponse(
               professor.Id, professor.Cpf, professor.Nome, "Professor Cadastrado Com Sucesso"), this));
        }
    }
}
