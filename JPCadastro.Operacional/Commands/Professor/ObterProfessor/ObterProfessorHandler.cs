using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Professor.ObterProfessor;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.ObterAluno
{
    public class ObterProfessorHandler : Notifiable,
        IRequestHandler<ObterProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public ObterProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(ObterProfessorRequest request,
            CancellationToken cancellationToken)
        {
            if (request==null)
            {
                AddNotification("ObterAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var professor = _repositoryProfessor.ObterPorId(request.Id);

            if (professor==null)
            {
                AddNotification("ObterProfessorHandler", "Professor não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            return Task.FromResult(new CommandResponse(new ObterProfessorResponse
            {
                Id= professor.Id,
                Cpf = professor.Cpf,
                Nome = professor.Nome,
                Telefone = professor.Telefone
            }, this));
        }
    }
}
