using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using MediatR;

namespace JPCadastro.Operacional.Commands.Matricula.AtualizarMatricula
{
    public class AtualizarMatriculaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }
        public Guid CursoId { get; set; }
        public Guid AlunoId { get; set; }
        public StatusMatricula Status { get; set; }
    }
}
