namespace JPCadastro.Operacional.Commands.Aluno.AtualizarAluno
{
    public class AtualizarAlunoResponse
    {
        public Guid Id { get; }
        public string Cpf { get; }
        public string Mensagem { get; }

        public AtualizarAlunoResponse(Guid id, string cpf, string mensagem)
        {
            Id=id;
            Cpf=cpf;
            Mensagem=mensagem;
        }
    }
}
