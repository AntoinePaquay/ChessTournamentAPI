﻿using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.DAL.Interfaces;
using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface ITournamentService 

    {
        bool Create(TournamentAddDTO tournamentAddDTO);
        bool Delete(Guid id);
    }
}