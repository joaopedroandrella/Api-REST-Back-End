using JPCadastro.Operacional.Entities.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPCadastro.Infra.Data.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<CursoEntity>
    {
        public void Configure(EntityTypeBuilder<CursoEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Periodo)
                .HasColumnType("tinyint")
                .IsRequired();
            builder.Navigation(x => x.Professor)
                .IsRequired(false);
            builder.ToTable("TAB_Curso");
        }
    }
}
