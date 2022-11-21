namespace JPCadastro.Operacional.Commands.Curso.RemoverCurso
{
    public class RemoverCursoResponse
    {
        public string Mensagem { get; set; }
        public RemoverCursoResponse(string mensagem)
        {
            Mensagem=mensagem;
        }
    }
}
