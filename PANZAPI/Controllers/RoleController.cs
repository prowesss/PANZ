using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Roles;
using PANZAPI.Queries;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("GetRoles")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> GetRolesAsync()
    {
        var request = new GetListOfRoles();
        var roles = await _mediator.Send(request);
        return Ok(roles);
    }

    [HttpPost]
    [Route("CreateRole")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        var request = new CreateRole { RoleName = roleName };
        var result = await _mediator.Send(request);

        return NoContent();
    }

    [HttpPut]
    [Route("EditRole/{oldRoleName}")]
    //[Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> UpdateRole(string oldRoleName, [FromBody] string newRoleName)
    {
        var role = new UpdateRole { OldRoleName = oldRoleName, NewRoleName = newRoleName };
        var result = await _mediator.Send(role);

        return Ok(role);
    }

    [HttpDelete]
    [Route("DeleteRole/{roleName}")]
    //[Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> DeleteRole(string roleName)
    {
        var request = new DeleteRole { RoleName = roleName };
        var result = await _mediator.Send(request);

        return result;
    }
}
