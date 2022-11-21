using JPCadastro.Core.Entities;
using System.Linq.Expressions;

namespace JPCadastro.Core.Interfaces.Base
{
    public interface IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>
    {
        #region Listar

        IEnumerable<TEntity> Listar();
        IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente);
        IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> Listar(Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> Listar(params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Sem Rastreamento

        IEnumerable<TEntity> ListarSemRastreamento();
        IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente);
        IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarSemRastreamento(Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarSemRastreamento(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarSemRastreamento(params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Por...

        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde);
        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente);
        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPor(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Por Sem Rastreamento...

        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde);
        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente);
        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, Func<TEntity, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntity> ListarPorSemRastreamento(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Id

        TEntity ObterPorId(TId id);
        TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        TEntity ObterPorId(TId id, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Id Sem Rastreamento

        TEntity ObterPorIdSemRastreamento(TId id);
        TEntity ObterPorIdSemRastreamento(TId id, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        TEntity ObterPorIdSemRastreamento(TId id, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por...

        TEntity ObterPor(Func<TEntity, bool> onde);
        TEntity ObterPor(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        TEntity ObterPor(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Sem Rastreamento...

        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde);
        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Verificação

        bool Existe(Func<TEntity, bool> onde);
        bool Existe(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        bool Existe(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Adicionar

        void Adicionar(TEntity entity);

        #endregion

        #region Atualizar

        void Atualizar(TEntity entity);

        #endregion

        #region Remover

        void Remover(TEntity entity);

        #endregion

        #region Query

        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        IQueryable<TEntity> Query(params string[] incluirPropriedadesNavegacao);

        #endregion
    }
}