namespace JPCadastro.Operacional.Commands.Matricula.ListarMatricula
{
    public class ListarMatriculaResponse
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public string? AlunoNome { get; set; }
        public Guid CursoId { get; set; }
        public string? CursoNome { get; set; }
        public string Status { get; set; }
    }
}
