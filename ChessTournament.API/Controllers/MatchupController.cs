using ChessTournament.BLL.Interfaces;
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
        public IActionResult SetResult(Guid matchupId, int result)
        {

        }
    }
}
