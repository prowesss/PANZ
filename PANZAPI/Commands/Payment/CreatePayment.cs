using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Models;

namespace PANZAPI.Commands.Payment
{
    public class CreatePayment : IRequest<IActionResult>
    {
        public PaymentMethod Payment { get; set; }
        public CreatePayment(PaymentMethod payment)
        {
            Payment = payment;
        }
    }
}