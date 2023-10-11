using MediatR;
using PANZAPI.Models.Authentication;

namespace PANZAPI.Commands.Authentication
{
    public class LoginUser:IRequest<UserToken>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
