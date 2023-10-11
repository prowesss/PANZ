using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Repositories.MemberPaymentStatus
{
    public class MemberPaymentStatusRepository : IMemberPaymentStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberPaymentStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembershipPaymentStatus>> GetMembershipPaymentStatusList()
        {
            return await _context.MembershipPaymentStatus.ToListAsync();
        }

        public async Task<MembershipPaymentStatus> GetMembershipPaymentStatusById(Guid id)
        {
            return await _context.MembershipPaymentStatus.FindAsync(id);
        }

        public async Task AddMembershipPaymentStatus(MembershipPaymentStatus status)
        {
            _context.MembershipPaymentStatus.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMembershipPaymentStatus(MembershipPaymentStatus status)
        {
            _context.MembershipPaymentStatus.Update(status);
            await _context.SaveChangesAsync();
        }
    }
}
