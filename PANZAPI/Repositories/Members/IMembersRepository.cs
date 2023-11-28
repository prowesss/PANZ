using PANZAPI.Models;

namespace PANZAPI.Repositories.Members
{
    public interface IMembersRepository
    {
        Task<IEnumerable<Member>> GetListOfMembers();
        Task<Member> GetMemberById(Guid Id);
        Task AddMember(Member member);
        Task UpdateMember(Member member);
        Task<Member> GetMembershipDetailsByUserId(string userId);
    }
}
