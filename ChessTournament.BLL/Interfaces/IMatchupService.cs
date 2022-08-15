using ChessTournament.BLL.DTO.Matchups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface IMatchupService
    {
        void SetResult(SetResultDTO dto);
    }
}
