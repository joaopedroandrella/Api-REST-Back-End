using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.AtualizarAluno
{
    public class AtualizarAlunoHandler : Notifiable,
        IRequestHandler<AtualizarAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;

        public AtualizarAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(AtualizarAlunoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AtualizarAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var aluno = _repositoryAluno.ObterPorId(request.Id);
            if (aluno==null)
            {
                AddNotification("AtualizarAlunoHandler", "Aluno Não Localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT ALUNO
            aluno.Atualizar(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(aluno);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryAluno.Atualizar(aluno);

            return Task.FromResult(new CommandResponse(new AtualizarAlunoResponse(
                aluno.Id, aluno.Cpf, "Aluno Atualizado Com Sucesso"), this));
        }
    }
}
