
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipActivity
{
    public class MembershipActivityRepository : IMembershipActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public MembershipActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MembershipActivityLog> Find(Guid id)
        {
            return await _context.MembershipActivityLogs.FindAsync(id);
        }

        public async Task Update(MembershipActivityLog membershipActivityLog)
        {
            _context.MembershipActivityLogs.Update(membershipActivityLog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MembershipActivityLog>> GetList()
        {
            return await _context.MembershipActivityLogs.ToListAsync();
        }

        public async Task AddMembershipActivity(MembershipActivityLog membershipActivityLog)
        {
            _context.MembershipActivityLogs.Add(membershipActivityLog);
            await _context.SaveChangesAsync();
        }
    }
}
