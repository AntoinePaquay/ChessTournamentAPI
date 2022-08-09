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
        where TEntity : IEntity<TKey>
    {
        protected ChessTournamentContext _context;

        public RepositoryBase(ChessTournamentContext context)
        {
            _context = context;
        }

        public TKey Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
