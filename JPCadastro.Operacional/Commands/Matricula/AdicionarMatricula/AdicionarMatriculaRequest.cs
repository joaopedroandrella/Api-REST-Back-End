using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using MediatR;

namespace JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula
{
    public class AdicionarMatriculaRequest : IRequest<CommandResponse>
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public string? AlunoNome { get; set; }
        public string? CursoNome { get; set; }
        public StatusMatricula Status { get; set; }
    }
}
