using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BksTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BksTest.DAL
{
    public class Context : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookingModel> Booking { get; set; }
        public DbSet<ApartmentModel> Apartments { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingModel>(entity =>
            {
                entity.HasOne(w => w.User)
                    .WithMany(w => w.Booking)
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(w => w.Apartment)
                    .WithMany(w => w.Bookings)
                    .HasForeignKey(w => w.ApartmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries<BaseModel>()
                .Where(e => e.State == EntityState.Added)
                .ToList()
                .ForEach(e =>
                {
                    if (e.State == EntityState.Added)
                        e.Entity.CreateDate = DateTime.UtcNow;
                });
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}