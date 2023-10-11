using MediatR;

namespace PANZAPI.Commands.Authentication
{
    public class ConfirmEmail: IRequest
    { 
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
