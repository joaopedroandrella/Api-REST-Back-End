using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Aluno.AdicionarProfessor
{
    public class AdicionarProfessorRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
