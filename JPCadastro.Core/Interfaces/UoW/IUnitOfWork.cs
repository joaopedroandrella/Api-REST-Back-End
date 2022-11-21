using JPCadastro.Core.DTOs;

namespace JPCadastro.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        CommitResult Commit();
    }
}
