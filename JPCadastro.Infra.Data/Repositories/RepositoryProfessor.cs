using JPCadastro.Infra.Data.Context;
using JPCadastro.Infra.Data.Repositories.Base;
using JPCadastro.Operacional.Entities.Professor;
using JPCadastro.Operacional.Interfaces.Repositories;

namespace JPCadastro.Infra.Data.Repositories
{
    public class RepositoryProfessor : RepositoryBase<ProfessorEntity, Guid>, IRepositoryProfessor
    {
        public RepositoryProfessor(JPCadastroContext context) : base(context)
        {
        }
    }
}
