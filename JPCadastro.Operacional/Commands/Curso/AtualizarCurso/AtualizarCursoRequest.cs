using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using MediatR;

namespace JPCadastro.Operacional.Commands.Curso.AtualizarCurso
{
    public class AtualizarCursoRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Periodo Periodo { get; set; }
        public Guid? ProfessorId { get; set; }
    }
}
