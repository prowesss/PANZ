using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetUsersById : IRequest<UserSummary>
    {
        public string UserId { get; }

        public GetUsersById(string userId)
        {
            UserId = userId;
        }
    }
}
