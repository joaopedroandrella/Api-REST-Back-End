using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Professor.ObterProfessor
{
    public class ObterProfessorRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }
        public ObterProfessorRequest(Guid id)
        {
            Id=id;
        }
    }
}
