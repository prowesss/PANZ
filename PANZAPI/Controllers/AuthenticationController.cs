using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Authentication;
using PANZAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("admin/registerUser")]
        public async Task<IActionResult> RegisterUserFromAdmin([FromBody] CreateUserFromAdmin request)
        {
            var user = await _mediator.Send(request);
            await _mediator.Send(new SendConfirmationEmail() { User = user });
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser request)
        {
            var user = await _mediator.Send(request);
            await _mediator.Send(new SendConfirmationEmail() { User = user });
            return Ok("User Registered !!");

        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var request = new ConfirmEmail()
            {
                Token = token,
                Email = email
            };
            await _mediator.Send(request);
            return NoContent();

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser request)
        {
            var userToken = await _mediator.Send(request);
            return Ok(userToken);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var command = new ForgotPassword
            {
                Email = email,
                Scheme = HttpContext.Request.Scheme,
                Host = HttpContext.Request.Host.Value
            };
            try
            {
                await _mediator.Send(command);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"Password change request sent to {email}. Please verify." });
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetUserPassword request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }





    }
}
