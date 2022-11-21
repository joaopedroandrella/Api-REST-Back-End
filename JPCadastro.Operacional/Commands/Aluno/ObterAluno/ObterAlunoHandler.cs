using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.ObterAluno
{
    public class ObterAlunoHandler : Notifiable,
        IRequestHandler<ObterAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;

        public ObterAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(ObterAlunoRequest request,
            CancellationToken cancellationToken)
        {
            if (request==null)
            {
                AddNotification("ObterAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var aluno = _repositoryAluno.ObterPorId(request.Id);

            if (aluno==null)
            {
                AddNotification("ObterAlunoHandler", "Aluno não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            return Task.FromResult(new CommandResponse(new ObterAlunoResponse
            {
                Id = aluno.Id,
                Cpf = aluno.Cpf,
                Nome = aluno.Nome,
                Telefone = aluno.Telefone
            }, this));
        }
    }
}
