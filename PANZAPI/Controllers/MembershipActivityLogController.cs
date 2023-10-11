using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.MembershipActivity;
using PANZAPI.Models;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipActivityLogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipActivityLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipActivityLog>>> GetMembershipActivityLogs(GetListOfMembershipType request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipActivityById(Guid id)
        { 
                var query = new GetMembershipActivityById(id);
                var result = await _mediator.Send(query);
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMembershipActivity request)
        {
            
                await _mediator.Send(request);
                return Ok("Membership activity log added successfully.");
             
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipActivityLog(UpdateMembershipActivity request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
