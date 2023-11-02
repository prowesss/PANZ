using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PANZAPI.Commands.Authentication
{
    public class ForgotPassword: IRequest
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
    }
}
