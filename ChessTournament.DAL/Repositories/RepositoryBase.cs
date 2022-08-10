using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Repositories
{
    public class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        protected ChessTournamentContext _context;

        public RepositoryBase(ChessTournamentContext context)
        {
            _context = context;
        }

        public virtual bool Create(TEntity entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public virtual bool Update(TEntity entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() == 1;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual TEntity? GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public virtual bool Delete(TKey id)
        {
            TEntity ?entity = GetById(id);
            if (entity is null) return false;
            _context.Remove(entity);
            return _context.SaveChanges() == 1;
        }

        public virtual bool Exists(Func<TEntity, bool> predicate)
        {
            if (predicate == null) return false;
            return _context.Set<TEntity>().Any(predicate);
        }
    }
}
