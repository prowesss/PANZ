using Microsoft.AspNetCore.Identity;

namespace PANZAPI.ModelsSummary
{
    public class UserSummary
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public UserSummary(IdentityUser user)
        {
            Id = user.Id;
            Email = user.Email;
            UserName = user.UserName;
        }
    }
}
