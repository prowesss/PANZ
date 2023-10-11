using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipStatuses
{
    public class MembershipStatusRepository : IMembershipStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public MembershipStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembershipStatus>> GetMembershipStatusesAsync()
        {
            return await _context.MembershipStatus.ToListAsync();
        }

        public async Task<MembershipStatus> GetMembershipStatusByIdAsync(Guid id)
        {
            return await _context.MembershipStatus.FindAsync(id);
        }

        public async Task<Guid> CreateMembershipStatusAsync(MembershipStatus membershipStatus)
        {
            _context.MembershipStatus.Add(membershipStatus);
            await _context.SaveChangesAsync();
            return membershipStatus.Id;
        }

        public async Task UpdateMembershipStatusAsync(Guid id, MembershipStatus membershipStatus)
        {
            var existingMembershipStatus = await _context.MembershipStatus.FindAsync(id);

            if (existingMembershipStatus != null)
            {
                _context.Entry(existingMembershipStatus).CurrentValues.SetValues(membershipStatus);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMembershipStatusAsync(Guid id)
        {
            var membershipStatus = await _context.MembershipStatus.FindAsync(id);

            if (membershipStatus != null)
            {
                _context.MembershipStatus.Remove(membershipStatus);
                await _context.SaveChangesAsync();
            }
        }
    }
}
