namespace JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula
{
    public class AdicionarMatriculaResponse
    {
        public string Mensagem { get; }

        public AdicionarMatriculaResponse(string mensagem)
        {
            Mensagem= mensagem;     
        }
    }
}
