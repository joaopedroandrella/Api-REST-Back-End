namespace JPCadastro.Operacional.Commands.Aluno.AdicionarAluno
{
    public class RemoverAlunoResponse
    {
        public string Cpf { get; }
        public string Mensagem { get; }

        public RemoverAlunoResponse(string cpf , string mensagem)
        {
            Cpf = cpf;
            Mensagem=mensagem;
        }
    }
}
