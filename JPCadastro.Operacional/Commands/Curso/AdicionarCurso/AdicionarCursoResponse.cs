namespace JPCadastro.Operacional.Commands.Curso.Atualizar
{
    public class AdicionarCursoResponse
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Mensagem { get; }

        public AdicionarCursoResponse(Guid id, string nome, string mensagem)
        {
            Id = id;
            Nome = nome;
            Mensagem = mensagem;
        }
    }
}
