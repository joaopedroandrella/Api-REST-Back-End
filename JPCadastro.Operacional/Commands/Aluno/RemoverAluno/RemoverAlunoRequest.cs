using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Aluno.RemoverAluno
{
    public class RemoverAlunoRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }

        public RemoverAlunoRequest(Guid id)
        {
            Id=id;
        }
    }
}
