using ChessTournament.DAL.Context;
using ChessTournament.DAL.Interfaces;
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

        public virtual TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => EqualityComparer<TKey>.Default.Equals(e.Id,id))!;
        }
        public virtual bool Delete(TKey id)
        {
            TEntity entity = GetById(id);
            _context.Remove(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
