using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Curso.AtualizarMatricula
{
    public class AtualizarMatriculaResponse
    {
        public Guid Id { get; }
        public Guid CursoId { get; }
        public Guid AlunoId { get; }
        public StatusMatricula Status { get; }
        public string Mensagem { get; }

        public AtualizarMatriculaResponse(Guid id, Guid cursoId, Guid alunoId, StatusMatricula status, string mensagem)
        {
            Id=id;
            CursoId=cursoId;
            AlunoId=alunoId;
            Status=status;
            Mensagem=mensagem;
        }
    }
}
