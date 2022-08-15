using ChessTournament.BLL.DTO.Matchups;
using ChessTournament.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchupController : ControllerBase
    {
        private IMatchupService _MatchupService;
        public MatchupController(IMatchupService matchupService)
        {
            _MatchupService = matchupService;
        }

        [HttpPatch]
        [Authorize("Admin")]
        public IActionResult SetResult(SetResultDTO dto)
        {
            try
            {
                _MatchupService.SetResult(dto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
