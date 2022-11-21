namespace JPCadastro.Operacional.Commands.Aluno.AdicionarAluno
{
    public class AdicionarAlunoResponse
    {
        public Guid Id { get; }
        public string Cpf { get; }
        public string Mensagem { get; }
        
        public AdicionarAlunoResponse(Guid id, string cpf, string mensagem)
        {
            Id=id;
            Cpf=cpf;
            Mensagem=mensagem;
        }
    }
}
