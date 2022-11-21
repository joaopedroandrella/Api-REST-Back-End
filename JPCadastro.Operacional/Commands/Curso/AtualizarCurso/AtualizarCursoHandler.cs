using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.AtualizarCurso
{
    public class AtualizarCursoHandler : Notifiable,
        IRequestHandler<AtualizarCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;
        private readonly IRepositoryProfessor _repositoryProfessor;

        public AtualizarCursoHandler(IRepositoryCurso repositoryCurso, IRepositoryProfessor repositoryProfessor)
        {
            _repositoryCurso=repositoryCurso;
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(AtualizarCursoRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AtualizarCursoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O CURSO JÁ ESTA CADASTRADO
            var curso = _repositoryCurso.ObterPorId(request.Id);
            if (curso==null)
            {
                AddNotification("AtualizarCursoHandler", "Curso Não Localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            //Verificando se o Professor Existe
            if (request.ProfessorId!=null)
            {
                if (!_repositoryProfessor.Existe(p => p.Id == request.ProfessorId))
                {
                    AddNotification("AtualizarCursoHandler", "Professor não Localizado");
                    return Task.FromResult(new CommandResponse(this));
                }
            }

            //CRIANDO O OBJT CURSO
            curso.Atualizar(
                request.Nome,
                request.Periodo,
                request.ProfessorId
                );
            AddNotifications(curso);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryCurso.Atualizar(curso);

            return Task.FromResult(new CommandResponse(new AtualizarCursoResponse(
                curso.Id, curso.Nome, curso.Periodo, curso.ProfessorId, "Curso Atualizado Com Sucesso"), this));
        }
    }
}
