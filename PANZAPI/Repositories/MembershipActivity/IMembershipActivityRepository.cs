using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipActivity
{
    public interface IMembershipActivityRepository
    {
        Task Update(MembershipActivityLog membershipActivityLog);
        Task<MembershipActivityLog> Find(Guid id);
        Task<IEnumerable<MembershipActivityLog>> GetList();
        Task AddMembershipActivity(MembershipActivityLog membershipActivityLog);
    }
}
