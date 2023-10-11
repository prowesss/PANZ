using MediatR;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.User;

namespace PANZAPI.Queries
{
    public class GetUsersByIdHandler : IRequestHandler<GetUsersById, UserSummary>
    {
        private readonly IUserRepository _userRepo;

        public GetUsersByIdHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserSummary> Handle(GetUsersById request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetUserById(request.UserId);
            return new UserSummary(user);
        }
    }
}
