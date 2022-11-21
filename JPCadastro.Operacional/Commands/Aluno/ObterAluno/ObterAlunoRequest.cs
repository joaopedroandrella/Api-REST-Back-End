using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Aluno.ObterAluno
{
    public class ObterAlunoRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }
        public ObterAlunoRequest(Guid id)
        {
            Id=id;
        }
    }
}
