using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Curso.ObterCurso
{
    public class ObterCursoRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public ObterCursoRequest(Guid id)
        {
            Id = id;
        }
    }
}
