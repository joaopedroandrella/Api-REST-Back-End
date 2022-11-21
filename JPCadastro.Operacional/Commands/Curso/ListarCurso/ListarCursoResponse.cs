using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Curso.ListarCurso
{
    public class ListarCursoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public string? ProfessorNome { get; set; }
        public Guid? ProfessorId { get; set; }
    }
}
