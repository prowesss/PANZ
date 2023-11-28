using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Repositories.Members
{
    public class MembersRepository : IMembersRepository
    {
        private readonly ApplicationDbContext _context;

        public MembersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetListOfMembers()
        {
            return await _context.Members
                .Include(m => m.MembershipPaymentStatus)
                .Include(m => m.MembershipStatus)
                .Include(m => m.MembershipType)
                .Include(m => m.PaymentMethod)
                .Where(m => m.IsActive).ToListAsync();
        }

        public async Task<Member> GetMemberById(Guid Id)
        {
            return await _context.Members
              .Include(m => m.MembershipPaymentStatus)
              .Include(m => m.MembershipStatus)
              .Include(m => m.MembershipType)
              .Include(m => m.PaymentMethod)
              .Where(m => m.IsActive)
              .FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<Member> GetMembershipDetailsByUserId(string userId)
        {
            return await _context.Members
       .Include(m => m.MembershipPaymentStatus)
       .Include(m => m.MembershipStatus)
       .Include(m => m.MembershipType)
       .Include(m => m.PaymentMethod)
       .Where(m => m.IsActive)
       .FirstOrDefaultAsync(m => m.UserId == userId);
        }

        public async Task AddMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateMember(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}
