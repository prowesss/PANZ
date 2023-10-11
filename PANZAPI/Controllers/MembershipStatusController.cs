using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.MembershipStats;
using PANZAPI.Models;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipStatus>>> GetMembershipStatuses()
        {
            var query = new GetListOfMembershipStatus();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipStatus>> GetMembershipStatus(Guid id)
        {
            var query = new GetMembershipStatusById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MembershipStatus>> CreateMembershipStatus(MembershipStatus membershipStatus)
        {
            var command = new CreateMembershipStatus { MembershipStatus = membershipStatus };
            var id = await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipStatus(Guid id, MembershipStatus membershipStatus)
        {
            var command = new UpdateMembershipStatus { Id = id, MembershipStatus = membershipStatus };
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembershipStatus(Guid id)
        {
            var command = new DeleteMembershipStatus { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
