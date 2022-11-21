namespace JPCadastro.Operacional.Commands.Professor.RemoverProfessor
{
    public class RemoverProfessorResponse
    {
        public string Mensagem { get; }

        public RemoverProfessorResponse(string mensagem)
        {
            Mensagem=mensagem;
        }
    }
}

