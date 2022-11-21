using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Matricula.ListarMatricula
{
    public class ListarMatriculaHandler : Notifiable,
        IRequestHandler<ListarMatriculaRequest, CommandResponse>
    {
        private readonly IRepositoryMatricula _repositoryMatricula;

        public ListarMatriculaHandler(IRepositoryMatricula repositoryMatricula)
        {
            _repositoryMatricula=repositoryMatricula;
        }

        public Task<CommandResponse> Handle(ListarMatriculaRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O MATRICULA JÁ ESTA CADASTRADO
            var colecaoMatricula = _repositoryMatricula.ListarSemRastreamento(p => p.Aluno, p => p.Curso);

            return Task.FromResult(new CommandResponse(colecaoMatricula.Select(p => new ListarMatriculaResponse
            {
                Id= p.Id,
                AlunoId= p.AlunoId,
                AlunoNome= p.Aluno?.Nome,
                CursoId= p.CursoId,
                CursoNome= p.Curso?.Nome,
                Status = p.Status == StatusMatricula.Ativo ? "Ativo" : "Desativado",
            }), this)); ;
        }
    }
}
