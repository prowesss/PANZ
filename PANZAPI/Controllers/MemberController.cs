using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Member;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Queries;
using Stripe.Checkout;

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
        public async Task<ActionResult<List<MemberSummary>>> GetAllMembers()
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

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetMemberDetailsByUserId(string userId)
        {
            var query = new GetMembershipDetailsByUserID(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMember request)
        {
                var member = await _mediator.Send(request);
                return Ok(member);
        }

        [HttpPost("{id}/payment")]
        public async Task<IActionResult> CreateMemberPayment([FromBody] CreateMemberPayment request)
        {
            var member = await _mediator.Send(request);
            return Ok(member);
        }

        [HttpPost("payment/success")]
        public async Task<IActionResult> PaymentSuccess()
        {
            try
            {
                if (!TryGetQueryString("memberId", out string memberId))
                {
                    return BadRequest("Invalid memberId");
                }

                var request = new CreateMemberPayment()
                {
                    PaymentMethodName = "Bank",
                    MemberId = new Guid(memberId),
                };

                if(TryGetQueryString("sessionId", out string sessionId)){
                    var sessionService = new SessionService();
                    var session = sessionService.Get(sessionId);
                    request.PaymentMethodName = "Stripe";
                    request.PaymentSessionId = sessionId;
                    request.PaymentReference = session.PaymentIntentId.ToString();
                }

                await _mediator.Send(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMember request)
        {
                request.Id = id;
                await _mediator.Send(request);
                return Ok($"Member with ID {id} updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
                var result = new DeleteMember { Id = id };
                await _mediator.Send(result);
                return NoContent();
        }

        private bool TryGetQueryString(string key, out string value)
        {
            value = Request.Query[key].FirstOrDefault();
            return !string.IsNullOrEmpty(value);
        }
    }
}
