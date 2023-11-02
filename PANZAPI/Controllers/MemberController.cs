using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Member;
using PANZAPI.Models;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            var query = new GetListOfMember();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var query = new GetListOfMemberById(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMember request)
        {
            
                var memberId = await _mediator.Send(request);
                return Ok($"Member added successfully with ID: {memberId}");
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMember request)
        {
                request.Id = id;
                await _mediator.Send(request);
                return Ok($"Member with ID {id} updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteMember request)
        {
                var result = new DeleteMember { Id = request.Id };
                await _mediator.Send(result);
                return Ok($"Member with ID {request.Id} soft deleted successfully.");
        }
    }
}
