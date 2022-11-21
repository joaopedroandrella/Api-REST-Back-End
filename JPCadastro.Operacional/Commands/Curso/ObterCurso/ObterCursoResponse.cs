using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Curso.ObterCurso
{
    public class ObterCursoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public  Periodo Periodo { get; set; }
        public Guid? ProfessorId { get; set; }
    }
}
