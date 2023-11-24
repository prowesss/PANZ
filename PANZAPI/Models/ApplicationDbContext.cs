using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PANZAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipActivityLog> MembershipActivityLogs { get; set; }
        public DbSet<MembershipPaymentStatus> MembershipPaymentStatus { get; set; }
        public DbSet<MembershipStatus> MembershipStatus { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Member>()
           .HasOne(m => m.PaymentMethod)
           .WithMany()
           .HasForeignKey(m => m.PaymentMethodId);

            builder.Entity<Member>()
               .HasOne(m => m.IdentityUser)
               .WithMany()
               .HasForeignKey(m => m.UserId);

            builder.Entity<Member>()
                .HasOne(m => m.MembershipStatus)
                .WithMany()
                .HasForeignKey(m => m.MembershipStatusId);

            builder.Entity<Member>()
                .HasOne(m => m.MembershipPaymentStatus)
                .WithMany()
                .HasForeignKey(m => m.MembershipPaymentStatusId);

            builder.Entity<Member>()
                .HasOne(m => m.MembershipType)
                .WithMany()
                .HasForeignKey(m => m.MembershipTypeId);

            builder.Entity<Member>()
       .HasOne(m => m.PaymentMethod)  // Navigation property
       .WithMany()  // Since PaymentMethod can be referenced by multiple members
       .HasForeignKey(m => m.PaymentMethodId)  // Foreign key property
       .IsRequired(false);

            builder.Entity<MembershipActivityLog>()
                .HasOne(mal => mal.Member)
                .WithMany()
                .HasForeignKey(mal => mal.MemberId);

            builder.Entity<MembershipActivityLog>()
                .HasOne(mal => mal.PaymentMethod)
                .WithMany()
                .HasForeignKey(mal => mal.PaymentMethodId);

            builder.Entity<MembershipActivityLog>()
                .HasOne(mal => mal.MembershipStatus)
                .WithMany()
                .HasForeignKey(mal => mal.MembershipStatusId);

            builder.Entity<MembershipActivityLog>()
                .HasOne(mal => mal.MembershipPaymentStatus)
                .WithMany()
                .HasForeignKey(mal => mal.MembershipPaymentStatusId);

            builder.Entity<MembershipActivityLog>()
                .HasOne(mal => mal.MembershipType)
                .WithMany()
                .HasForeignKey(mal => mal.MembershipTypeId);
        }
    }
}
