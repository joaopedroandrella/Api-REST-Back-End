using JPCadastro.Core.Entities;

namespace JPCadastro.Operacional.Entities.Aluno
{
    public class AlunoEntity : EntityBase<Guid>
    {
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }

        //CONSTRUTOR EF
        protected AlunoEntity() { }

        public AlunoEntity(string cpf, string nome, string telefone)
        {
            Id = Guid.NewGuid();
            Cpf=cpf;
            Nome=nome;
            Telefone=telefone;
            this.AdicionarAtualizarAlunoContract();
        }

        public void Atualizar(string cpf, string nome, string telefone)
        {
            Cpf=cpf;
            Nome=nome;
            Telefone=telefone;
            this.AdicionarAtualizarAlunoContract();
        }
    }
}
