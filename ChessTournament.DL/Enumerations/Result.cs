using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Enumerations
{
    /*public enum Result
    {
        BlackByCheckmate,
        BlackByResignation,
        BlackByTimeOut,
        WhiteByCheckmate,
        WhiteByResignation,
        WhiteByTimeOut,
        DrawStaleMate,
        DrawInsufficientMaterial,
        DrawFiftyMoves,
        DrawRepetition,
        DrawAgreement
    }*/

    public enum Result
    {
        Black,
        White,
        Draw,
        PendingResult
    }
}
