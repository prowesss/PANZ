using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipStatuses
{
    public interface IMembershipStatusRepository
    {
        Task<IEnumerable<MembershipStatus>> GetMembershipStatuses();
        Task<MembershipStatus> GetMembershipStatusByIdAsync(Guid id);
        Task<Guid> CreateMembershipStatusAsync(MembershipStatus membershipStatus);
        Task UpdateMembershipStatusAsync(Guid id, MembershipStatus membershipStatus);
        Task DeleteMembershipStatusAsync(Guid id);
    }
}
