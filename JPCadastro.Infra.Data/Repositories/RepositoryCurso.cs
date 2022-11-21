using JPCadastro.Infra.Data.Context;
using JPCadastro.Infra.Data.Repositories.Base;
using JPCadastro.Operacional.Entities.Curso;
using JPCadastro.Operacional.Interfaces.Repositories;

namespace JPCadastro.Infra.Data.Repositories
{
    public class RepositoryCurso : RepositoryBase<CursoEntity, Guid>, IRepositoryCurso
    {
        public RepositoryCurso(JPCadastroContext context) : base(context)
        {
        }
    }
}
