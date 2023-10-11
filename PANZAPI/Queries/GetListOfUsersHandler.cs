using MediatR;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.User;

namespace PANZAPI.Queries
{
    public class GetListOfUsersHandler : IRequestHandler<GetListOfUsers, IEnumerable<UserSummary>>
    {
        private readonly IUserRepository _userRepo;

        public GetListOfUsersHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserSummary>> Handle(GetListOfUsers request, CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetListOfUsers();
            return users.Select(x => new UserSummary(x));
        }
    }
}
