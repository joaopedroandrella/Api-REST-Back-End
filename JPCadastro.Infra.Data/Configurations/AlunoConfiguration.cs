using JPCadastro.Operacional.Entities.Aluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPCadastro.Infra.Data.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<AlunoEntity>
    {
        public void Configure(EntityTypeBuilder<AlunoEntity> builder)
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
            builder.ToTable("TAB_Aluno");
        }
    }
}
