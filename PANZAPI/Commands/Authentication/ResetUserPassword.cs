using MediatR;

namespace PANZAPI.Commands.Authentication
{
    public class ResetUserPassword:IRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
