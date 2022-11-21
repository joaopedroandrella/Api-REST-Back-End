using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Matricula.RemoverMatricula
{
    public class RemoverMatriculaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public RemoverMatriculaRequest(Guid id)
        {
            Id=id;
        }
    }
}
