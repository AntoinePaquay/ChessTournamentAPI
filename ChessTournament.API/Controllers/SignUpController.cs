using ChessTournament.BLL.DTO.SignUps;
using ChessTournament.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        ISignUpService _Service;

        public SignUpController(ISignUpService service)
        {
            _Service = service;
        }

        [HttpPost]
        [Authorize("Auth")]
        public IActionResult TournamentSignUp(SignUpDTO dto)
        {
            string memberId = User.FindFirst(ClaimTypes.Sid)?.Value ?? throw new ArgumentNullException("Couldn't retrieve user id from jwt token.");
            Guid id;
            try
            {
                id = new Guid(memberId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            _Service.SignUp(dto, id);
            return Ok();
        }

        [HttpDelete]
        [Authorize("Auth")]
        public IActionResult Withdraw(WithdrawDTO dto)
        { 
            string memberId = User.FindFirst(ClaimTypes.Sid)?.Value ?? throw new ArgumentNullException("Couldn't retrieve user id from jwt token.");
            Guid id;
            try
            {
                id = new Guid(memberId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            try
            {
                _Service.Withdraw(dto, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
