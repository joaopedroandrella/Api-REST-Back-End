using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Matricula.ObterMatricula
{
    public class ObterMatriculaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public ObterMatriculaRequest(Guid id)
        {
            Id = id;
        }
    }
}
