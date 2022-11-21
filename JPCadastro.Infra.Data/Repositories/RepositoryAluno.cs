using JPCadastro.Infra.Data.Context;
using JPCadastro.Infra.Data.Repositories.Base;
using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Interfaces.Repositories;

namespace JPCadastro.Infra.Data.Repositories
{
    public class RepositoryAluno : RepositoryBase<AlunoEntity, Guid>, IRepositoryAluno
    {
        public RepositoryAluno(JPCadastroContext context) : base(context)
        {
        }
    }
}
