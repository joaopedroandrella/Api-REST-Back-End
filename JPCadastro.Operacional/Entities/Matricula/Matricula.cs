using JPCadastro.Core.Entities;
using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Entities.Curso;
using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Entities.Matricula
{
    public class MatriculaEntity : EntityBase<Guid>
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public StatusMatricula Status { get; set; }
        public AlunoEntity Aluno {get; set;}
        public CursoEntity Curso { get; set; }

        protected MatriculaEntity() { }

        public MatriculaEntity(Guid alunoId, Guid cursoId, StatusMatricula status, string? alunoNome, string? cursoNome)
        {
            Id= Guid.NewGuid();
            AlunoId= alunoId;
            CursoId= cursoId;
            Status= status;
        }
        public void Atualizar(Guid cursoId, StatusMatricula status)
        {
            CursoId= cursoId;
            Status= status;
            this.AdicionarAtualizarMatriculaContract();
        }
    }
}
