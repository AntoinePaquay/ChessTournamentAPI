using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        ITournamentService _service;

        public TournamentController(ITournamentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(TournamentAddDTO tournamentAddDTO)
        {
            _service.Create(tournamentAddDTO);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}