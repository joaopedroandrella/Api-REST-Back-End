using JPCadastro.Operacional.Entities.Professor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPCadastro.Infra.Data.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<ProfessorEntity>
    {
        public void Configure(EntityTypeBuilder<ProfessorEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cpf)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Telefone)
                .HasMaxLength(20);
            builder.ToTable("TAB_Professor");
        }
    }
}
