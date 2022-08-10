using ChessTournament.BLL.DTO.Members;
using ChessTournament.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private IAuthentificationService _Service;
        public AuthentificationController(IAuthentificationService service)
        {
            _Service = service;
        }
        [HttpPost]
        public IActionResult Register(MemberRegisterDTO dto)
        {
            _Service.Register(dto);
            return Ok();
        }
    }
}
