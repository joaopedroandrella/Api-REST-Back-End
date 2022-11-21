using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Curso.AtualizarCurso
{
    public class AtualizarCursoResponse
    {
        public Guid Id { get; }
        public string Nome { get; }
        public Periodo Periodo { get; }
        public Guid? ProfessorId { get; }
        public string Mensagem { get; }

        public AtualizarCursoResponse(Guid id, string nome, Periodo periodo, Guid? professorId, string mensagem)
        {
            Id=id;
            Nome=nome;
            Periodo=periodo;
            ProfessorId=professorId;
            Mensagem=mensagem;
        }
    }
}
