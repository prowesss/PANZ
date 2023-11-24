using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.MembershipPaymentStatus;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPaymentStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipPaymentStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<MembershipPaymentStatusSummary>> Get()
        {
            var query = new GetListOfMembershipPaymentStatus();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetMembershipPaymentStatusById { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMembershipPaymentStatus request)
        {
            var newStatusId = await _mediator.Send(request);
            return Ok($"MembershipPaymentStatus added successfully with ID: {newStatusId}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMembershipPaymentStatus request)
        {
            request.Id = id;
            await _mediator.Send(request);
            return Ok($"MembershipPaymentStatus with ID {id} updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteMembershipPaymentStatus { Id = id };
            await _mediator.Send(request);
            return Ok($"MembershipPaymentStatus with ID {id} soft deleted successfully.");
        }
    }
}
