using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PANZAPI.Queries;
using PANZAPI.Commands.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using PANZAPI.Commands.Roles;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMediator _mediator;

    public UserController(UserManager<IdentityUser> userManager, IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }

    [HttpGet("list")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> GetListOfUsers()
    {
        var request = new GetListOfUsers();
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var request = new GetUsersById(id);
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUser request)
    {
        var user = await _mediator.Send(request);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result.Errors);
        }
        return NotFound();
    }

    //[Authorize(Roles = "SuperAdmin")]
    [HttpPost("assignSuperAdminRole/{userId}")]
    public async Task<IActionResult> AssignSuperAdminRole(string userId)
    {
        var command = new AssignSuperAdminRole { UserId = userId };
        var result = await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("userinfo")]
    public async Task<IActionResult> GetUserInfoAsync()
    {
        // Retrieve the current user's email from the claims
        var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        if (emailClaim == null)
        {
            return BadRequest("Email claim not found.");
        }

        var email = emailClaim.Value;

        // Use UserManager to find the user based on their email
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return NotFound($"User with email {email} not found.");
        }
        var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        // You can return any user information you need
        var userInfo = new
        {
            Id = user.Id,
            UserName = user.UserName,
            IsAdmin = roleClaim.Value == "Admin"
        };

        return Ok(userInfo);
    }
}

