using ChessTournament.BLL.Interfaces;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _repository;

        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public bool Create(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Tournament> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tournament? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
