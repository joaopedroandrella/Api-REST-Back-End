using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Entities.Matricula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPCadastro.Infra.Data.Configurations
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<MatriculaEntity>
    {
        public void Configure(EntityTypeBuilder<MatriculaEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AlunoId)
                .IsRequired();
            builder.Property(x => x.CursoId)
                .IsRequired();
            builder.Property(x => x.Status)
                .HasColumnType("tinyint")
                .IsRequired();
            builder.Navigation(x => x.Aluno)
                .IsRequired();
            builder.Navigation(x => x.Curso)
                .IsRequired();
            builder.ToTable("TAB_Matricula");
        }
    }
}
