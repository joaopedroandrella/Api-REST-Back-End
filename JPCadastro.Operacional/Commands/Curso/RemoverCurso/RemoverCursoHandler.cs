using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.RemoverCurso
{
    public class RemoverCursoHandler : Notifiable,
        IRequestHandler<RemoverCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;

        public RemoverCursoHandler(IRepositoryCurso repositoryCurso)
        {
            _repositoryCurso=repositoryCurso;
        }

        public Task<CommandResponse> Handle(RemoverCursoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("RemoverCursoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O CURSO JÁ ESTA CADASTRADO
            var curso = _repositoryCurso.ObterPorId(request.Id);
            if (curso==null)
            {
                AddNotification("RemoverCursoHandler", "Curso não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryCurso.Remover(curso);

            return Task.FromResult(new CommandResponse(new RemoverCursoResponse(
                "Curso Removido Com Sucesso"), this));
        }
    }
}
