using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PANZ.Service.Services;
<<<<<<< Updated upstream
=======
using PANZAPI.Commands.Authentication;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already exists!" });
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User failed to create" });
                }
                //Add role to the user

                await _userManager.AddToRoleAsync(user, role);

                //Add token to verify the email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Confirmation Email link", confirmationLink!);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"User created successfully and Email sent to  {user.Email}" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "This role doesnot exist" });
            }

=======
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
>>>>>>> Stashed changes
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
