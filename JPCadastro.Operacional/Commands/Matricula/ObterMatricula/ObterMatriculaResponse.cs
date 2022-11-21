using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Matricula.ObterMatricula
{
    public class ObterMatriculaResponse
    {
        public Guid Id { get; set; }
        public Guid CursoId { get; set; }
        public Guid AlunoId { get; set; }
        public StatusMatricula Status { get; set; }
    }
}
