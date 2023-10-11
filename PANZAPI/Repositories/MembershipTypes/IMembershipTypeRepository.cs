using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipTypes
{
    public interface IMembershipTypeRepository
    {
        Task<IEnumerable<MembershipType>> GetMembershipTypesAsync();
        Task<MembershipType> GetMembershipTypeByIdAsync(Guid id);
        Task<Guid> CreateMembershipTypeAsync(MembershipType membershipType);
        Task UpdateMembershipTypeAsync(Guid id, MembershipType membershipType);
        Task DeleteMembershipTypeAsync(Guid id);
    }
}
