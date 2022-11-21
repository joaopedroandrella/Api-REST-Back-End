using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Curso.RemoverCurso
{
    public class RemoverCursoRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public RemoverCursoRequest(Guid id)
        {
            Id=id;
        }
    }
}
