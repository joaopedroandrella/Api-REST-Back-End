using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Enumeradores;
using MediatR;

namespace JPCadastro.Operacional.Commands.Curso.Atualizar
{
    public class AdicionarCursoRequest : IRequest<CommandResponse>
    {
        public string Nome { get; set; }
        public Periodo Periodo { get; set; }
        public Guid? ProfessorId { get; set;}
        public string? ProfessorNome { get; set; }
    }
}
