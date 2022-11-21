using JPCadastro.Core.Entities;
using JPCadastro.Core.Interfaces.Base;
using JPCadastro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JPCadastro.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly JPCadastroContext Context;

        public RepositoryBase(JPCadastroContext context)
        {
            DbSet = context.Set<TEntity>();
            Context = context;
        }

        #region Listar
        public IEnumerable<TEntity> Listar()
        {
            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsEnumerable();

            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> Listar(params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsEnumerable();

            return DbSet.AsEnumerable();
        }

        #endregion

        #region Listar Sem Rastreamento

        public IEnumerable<TEntity> ListarSemRastreamento()
        {
            return DbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().AsEnumerable();

            return DbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento(params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().AsEnumerable();

            return DbSet.AsNoTracking().AsEnumerable();
        }

        #endregion

        #region Listar Por...

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde)
        {
            return DbSet.Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Where(onde).AsEnumerable();

            return DbSet.Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Where(onde).AsEnumerable();

            return DbSet.Where(onde).AsEnumerable();
        }

        #endregion

        #region Listar Por Sem Rastreamento...

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde)
        {
            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).AsEnumerable();

            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).AsEnumerable();

            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        #endregion

        #region ObterPorId

        public TEntity ObterPorId(TId id)
        {
            return DbSet.Find(id);
        }

        public TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.Equals(id));

            return DbSet.FirstOrDefault(p => p.Id.Equals(id));
        }

        public TEntity ObterPorId(TId id, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.Equals(id));

            return DbSet.FirstOrDefault(p => p.Id.Equals(id));
        }

        #endregion

        #region ObterPorIdSemRastreamento...

        public TEntity ObterPorIdSemRastreamento(TId id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => p.Id.Equals(id));
        }

        public TEntity ObterPorIdSemRastreamento(TId id, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.Equals(id));

            return DbSet.FirstOrDefault(p => p.Id.Equals(id));
        }

        public TEntity ObterPorIdSemRastreamento(TId id, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.Equals(id));

            return DbSet.FirstOrDefault(p => p.Id.Equals(id));
        }


        #endregion

        #region ObterPor

        public TEntity ObterPor(Func<TEntity, bool> onde)
        {
            return DbSet.FirstOrDefault(onde);
        }

        public TEntity ObterPor(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        public TEntity ObterPor(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        #endregion

        #region ObterPorSemRastreamento

        public TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde)
        {
            return DbSet.AsNoTracking().FirstOrDefault(onde);
        }

        public TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().FirstOrDefault(onde);

            return DbSet.AsNoTracking().FirstOrDefault(onde);
        }

        public TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().FirstOrDefault(onde);

            return DbSet.AsNoTracking().FirstOrDefault(onde);
        }

        #endregion

        #region Verificação

        public bool Existe(Func<TEntity, bool> onde)
        {
            return DbSet.Any(onde);
        }

        public bool Existe(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Any(onde);

            return DbSet.Any(onde);
        }

        public bool Existe(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Any(onde);

            return DbSet.Any(onde);
        }


        #endregion

        #region Adicionar

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        #endregion

        #region Atualizar

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        #endregion

        #region Remover

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        #endregion

        #region Query

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao);

            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> Query(params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao);

            return DbSet.AsQueryable();
        }


        #endregion

        #region Inclusão de Propriedades de Navegação

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao)
        {
            foreach (var property in incluirPropriedadesNavegacao)
                query = query.Include(property);

            return query;
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params string[] incluirPropriedadesNavegacao)
        {
            foreach (var property in incluirPropriedadesNavegacao)
                query = query.Include(property);

            return query;
        }

        #endregion
    }
}
