using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Curso.AtualizarMatricula;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Matricula.AtualizarMatricula
{
    public class AtualizarMatriculaHandler : Notifiable,
        IRequestHandler<AtualizarMatriculaRequest, CommandResponse>
    {
        private readonly IRepositoryMatricula _repositoryMatricula;
        private readonly IRepositoryAluno _repositoryAluno;
        private readonly IRepositoryCurso _repositoryCurso;


        public AtualizarMatriculaHandler(IRepositoryMatricula repositoryMatricula, IRepositoryAluno repositoryAluno,
                                         IRepositoryCurso repositoryCurso)
        {
            _repositoryMatricula=repositoryMatricula;
            _repositoryAluno=repositoryAluno;
            _repositoryCurso=repositoryCurso;
        }

        public Task<CommandResponse> Handle(AtualizarMatriculaRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AtualizarMatriculaHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O MATRICULA JÁ ESTA CADASTRADO
            var Matricula = _repositoryMatricula.ObterPorId(request.Id);
            if (Matricula==null)
            {
                AddNotification("AtualizarMatriculaHandler", "Matricula Não Localizada");
                return Task.FromResult(new CommandResponse(this));
            }

            //Verificando se o Aluno Existe
            if (request.AlunoId!=null)
            {
                if (!_repositoryAluno.Existe(p => p.Id == request.AlunoId))
                {
                    AddNotification("AtualizarMatriculaHandler", "Aluno não Localizado");
                    return Task.FromResult(new CommandResponse(this));
                }
            }

            //Vereficando se o Curso Existe
            if (request.CursoId!=null)
            {
                if (!_repositoryCurso.Existe(p => p.Id == request.CursoId))
                {
                    AddNotification("AtualizarMatriculaHandler", "Curso não Localizado");
                    return Task.FromResult(new CommandResponse(this));
                }
            }

            //CRIANDO O OBJT MATRICULA
            Matricula.Atualizar(
                request.CursoId,
                request.Status
                ); ;
            AddNotifications(Matricula);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryMatricula.Atualizar(Matricula);

            return Task.FromResult(new CommandResponse(new AtualizarMatriculaResponse(
                Matricula.Id,Matricula.CursoId,Matricula.AlunoId,Matricula.Status, "Matricula Atualizada Com Sucesso"), this));
        }
    }
}
