using JPCadastro.Core.DTOs;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Infra.Data.Context;

namespace JPCadastro.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JPCadastroContext _context;

        public UnitOfWork(JPCadastroContext context)
        {
            _context=context;
        }

        public CommitResult Commit()
        {
            try
            {
                var x = _context.SaveChanges();
                return new CommitResult(true, null, null);
            }
            catch (Exception ex)
            {
                return new CommitResult(false, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
