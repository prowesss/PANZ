using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Repositories.MembershipTypes
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToListAsync();
        }

        public async Task<MembershipType> GetMembershipTypeByIdAsync(Guid id)
        {
            return await _context.MembershipTypes.FindAsync(id);
        }

        public async Task<Guid> CreateMembershipTypeAsync(MembershipType membershipType)
        {
            _context.MembershipTypes.Add(membershipType);
            await _context.SaveChangesAsync();
            return membershipType.Id;
        }

        public async Task UpdateMembershipTypeAsync(Guid id, MembershipType membershipType)
        {
            var existingMembershipType = await _context.MembershipTypes.FindAsync(id);

            if (existingMembershipType != null)
            {
                _context.Entry(existingMembershipType).CurrentValues.SetValues(membershipType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMembershipTypeAsync(Guid id)
        {
            var membershipType = await _context.MembershipTypes.FindAsync(id);

            if (membershipType != null)
            {
                _context.MembershipTypes.Remove(membershipType);
                await _context.SaveChangesAsync();
            }
        }
    }

}
