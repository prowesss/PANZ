using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Commands.Member;
using PANZAPI.Models.Stripe;
using PANZAPI.Repositories.PaymentMethods;
using Stripe;
using Stripe.Checkout;

namespace PANZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPaymentMethodsRepository _paymentMethodRepo;

        public StripeController(IMediator mediator, IPaymentMethodsRepository paymentMethodRepo)
        {
            _mediator = mediator;
            _paymentMethodRepo = paymentMethodRepo;
            StripeConfiguration.ApiKey = "sk_test_51OCMJLG05pyFeIhHaBqmZaaBbLr7rEBleTsbC4Qs5qKZjzsrsRUdI9FjSgLWKVZIfMYsnLencggjZkaoCWMIm2qV005TRqYYyR";
        }

        [HttpPost("create-checkout-session")]

        public async Task<IActionResult> CreatecheckoutSession([FromBody] CreateCheckoutSessionRequest req)
        {
            Console.WriteLine("CreatecheckoutSession method called.");
            var options = new SessionCreateOptions
            {
                SuccessUrl = "http://localhost:4200/payment/success?memberId=" + req.MemberId + "&sessionId={CHECKOUT_SESSION_ID}",
                //SuccessUrl = "https://localhost:4200/member/edit?session_id={CHECKOUT_SESSION_ID}"+"&member_id=" + req.MemberId,
                CancelUrl = "https://exapmle.com/canceled.html",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = req.PriceId,
                        Quantity = 1,
                    },
                },
            };


            var service = new SessionService();
            try
            {
                var session = await service.CreateAsync(options);
                return Ok(new CreateCheckoutSessionResponse
                {
                    SessionId = session.Id,
                });
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest(new ErrorResponse
                {
                    ErrorMessage = new ErrorMessage
                    {
                        Message = e.StripeError.Message
                    }
                });
            }
        }
    }
}
