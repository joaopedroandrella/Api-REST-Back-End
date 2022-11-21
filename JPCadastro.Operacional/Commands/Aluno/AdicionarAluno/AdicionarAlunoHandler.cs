using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.AdicionarAluno
{
    public class AdicionarAlunoHandler : Notifiable,
        IRequestHandler<AdicionarAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;


        public AdicionarAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(AdicionarAlunoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT ALUNO
           var aluno = new AlunoEntity(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(aluno);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryAluno.Adicionar(aluno);

            return Task.FromResult(new CommandResponse(new AdicionarAlunoResponse(
                aluno.Id, aluno.Cpf, "Aluno Cadastrado Com Sucesso"), this));
        }
    }
}
