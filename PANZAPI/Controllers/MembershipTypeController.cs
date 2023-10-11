using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.MembershipTypes;
using PANZAPI.Models;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipType>>> GetMembershipTypes()
        {
            var request = new GetListOfMembership();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipType>> GetMembershipType(Guid id)
        {
            var request = new GetMembershipById { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MembershipType>> CreateMembershipType(MembershipType membershipType)
        {
            var request = new CreateMembershipType { MembershipType = membershipType };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipType(Guid id, MembershipType membershipType)
        {
            var command = new UpdateMembershipType { Id = id, MembershipType = membershipType };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembershipType(Guid id)
        {
            var request = new DeleteMembershipType { Id = id };
            await _mediator.Send(request);
            return NoContent();
        }

    }
}
