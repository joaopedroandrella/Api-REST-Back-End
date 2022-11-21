namespace JPCadastro.Operacional.Commands.Professor.AdicionarProfessor
{
    public class AdicionarProfessorResponse
    {
        public Guid Id { get; }
        public string Cpf { get; }
        public string Nome { get; }
        public string Mensagem { get; }

        public AdicionarProfessorResponse(Guid id, string cpf, string nome, string mensagem)
        {
            Id = id;
            Cpf=cpf;
            Nome=nome;
            Mensagem=mensagem;
        }
    }
}
