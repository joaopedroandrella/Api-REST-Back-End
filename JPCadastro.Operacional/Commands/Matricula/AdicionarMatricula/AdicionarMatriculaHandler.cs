using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Entities.Matricula;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula
{
    public class AdicionarMatriculaHandler : Notifiable,
        IRequestHandler<AdicionarMatriculaRequest, CommandResponse>
    {
        private readonly IRepositoryMatricula _repositoryMatricula;

        public AdicionarMatriculaHandler(IRepositoryMatricula repositoryMatricula)
        {
            _repositoryMatricula=repositoryMatricula;
        }

        public Task<CommandResponse> Handle(AdicionarMatriculaRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarMatriculaHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT MATRICULA
            var Matricula = new MatriculaEntity(
                request.AlunoId,
                request.CursoId,
                request.Status,
                request.AlunoNome,
                request.CursoNome
                 ) ;
            AddNotifications(Matricula);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryMatricula.Adicionar(Matricula);

            return Task.FromResult(new CommandResponse(new AdicionarMatriculaResponse(
               "Matricula Cadastrada Com Sucesso"), this));
        }
    }
}
