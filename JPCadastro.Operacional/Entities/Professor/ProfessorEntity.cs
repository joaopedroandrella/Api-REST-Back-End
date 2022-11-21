using JPCadastro.Core.Entities;

namespace JPCadastro.Operacional.Entities.Professor
{
    public class ProfessorEntity : EntityBase<Guid>
    {
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }

        //CONSTRUTOR EF
        protected ProfessorEntity() { }

        public ProfessorEntity(string cpf, string nome, string telefone)
        {
            Id=Guid.NewGuid();
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
        }
        public void Atualizar(string cpf, string nome, string telefone)
        {
            Cpf=cpf;
            Nome=nome;
            Telefone=telefone;
            this.AdicionarAtualizarProfessorContract();
        }
    }
}