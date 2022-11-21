namespace JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula
{
    public class RemoverMatriculaResponse
    {
        public string Mensagem { get; }

        public RemoverMatriculaResponse(string mensagem)
        {
            Mensagem=mensagem;
        }
    }
}
