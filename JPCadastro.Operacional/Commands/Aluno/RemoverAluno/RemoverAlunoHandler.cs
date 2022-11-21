using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Aluno.AdicionarAluno;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.RemoverAluno
{
    public class RemoverAlunoHandler : Notifiable,
        IRequestHandler<RemoverAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;

        public RemoverAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(RemoverAlunoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("RemoverAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var aluno = _repositoryAluno.ObterPorId(request.Id);
            if (aluno==null)
            {
                AddNotification("RemoverAlunoHandler", "Aluno não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryAluno.Remover(aluno);

            return Task.FromResult(new CommandResponse(new RemoverAlunoResponse(
              aluno.Cpf,  "Aluno Removido Com Sucesso"), this)); ;
        }
    }
}
