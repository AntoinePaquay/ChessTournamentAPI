using ChessTournament.BLL.DTO;
using ChessTournament.BLL.DTO.Authentification;
using ChessTournament.BLL.DTO.Members;
using ChessTournament.BLL.Interfaces;
using ChessTournament.DL.Entities;
using ChessTournament.IL.Exceptions;
using ChessTournament.IL.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthentificationService _Service;
        private TokenManager _TokenManager;
        public AuthController(IAuthentificationService service, TokenManager tokenManager)
        {
            _Service = service;
            _TokenManager = tokenManager;
        }
        [HttpPost("Register")]
        public IActionResult Register(MemberRegisterDTO dto)
        {
            try
            {
                _Service.Register(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }            
        }

        [HttpPost("Login")]
        public IActionResult Login(MemberLoginDTO dto)
        {
            TokenDTO tokenDTO;
            try
            {
                tokenDTO = _Service.Login(dto);
                return Ok(_TokenManager.GenerateToken(tokenDTO.Pseudo, tokenDTO.Id.ToString(), tokenDTO.Role.ToString()));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
        }
    }
}
