namespace JPCadastro.Operacional.Commands.Professor.AtualizarProfessor
{
    public class AtualizarProfessorResponse
    {
        public Guid Id { get; set; }
        public string Cpf { get; }
        public string Nome { get; }
        public string Mensagem { get; }
        
        public AtualizarProfessorResponse(Guid id, string cpf, string nome, string mensagem)
        {
            Id=id;
            Cpf=cpf;
            Nome=nome;
            Mensagem=mensagem;
        }


    }
}
