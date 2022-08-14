using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Interfaces
{
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        bool Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(TKey id);
        void Update(TEntity entity);
        bool Delete(TKey id);
        bool Exists(Func<TEntity, bool> predicate);
        int Count(Func<TEntity, bool> predicate);
        int SaveChanges();
    }
}
