using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Payment;
using PANZAPI.Models;
using PANZAPI.Queries;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfPayments()
        {
            var request = new GetListOfPayments();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(Guid id)
        {
            var request = new GetPaymentById(id);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentMethod payment)
        {
            var request = new CreatePayment(payment);
            var result = await _mediator.Send(request);
            return result;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(Guid id, PaymentMethod payment)
        {
            var request = new UpdatePayment(id, payment);
            var result = await _mediator.Send(request);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            var command = new DeletePayment(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
