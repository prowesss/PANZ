using PANZAPI.Models;

namespace PANZAPI.Repositories.MemberPaymentStatus
{
    public interface IMemberPaymentStatusRepository
    {
        Task<IEnumerable<MembershipPaymentStatus>> GetMembershipPaymentStatusList();
        Task<MembershipPaymentStatus> GetMembershipPaymentStatusById(Guid id);
        Task AddMembershipPaymentStatus(MembershipPaymentStatus status);
        Task UpdateMembershipPaymentStatus(MembershipPaymentStatus status);
    }
}
