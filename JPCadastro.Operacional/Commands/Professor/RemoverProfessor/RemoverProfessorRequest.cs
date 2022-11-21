using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Professor.RemoverProfessor
{
    public class RemoverProfessorRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public RemoverProfessorRequest(Guid id)
        {
            Id = id;
        }

    }
}
