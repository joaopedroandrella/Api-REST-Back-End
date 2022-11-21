using JPCadastro.Infra.Data.Context;
using JPCadastro.Infra.Data.Repositories.Base;
using JPCadastro.Operacional.Entities.Matricula;
using JPCadastro.Operacional.Interfaces.Repositories;

namespace JPCadastro.Infra.Data.Repositories
{
    public class RepositoryMatricula : RepositoryBase<MatriculaEntity, Guid>, IRepositoryMatricula
    {
        public RepositoryMatricula(JPCadastroContext context) : base(context)
        {
        }
    }
}
