using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TruckDemo_v1.Application.Data;
using TruckDemo_v1.Domain.Entities;
using TruckDemo_v1.Domain.Entities.Identity;

namespace TruckDemo_v1.Infraestructure.Data
{
    public class TruckDemoContext : IdentityDbContext<ApplicationUser,Role,Guid>, ITruckDemoContext
    {
        public TruckDemoContext(DbContextOptions<TruckDemoContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Lesson> Lessons => Set<Lesson>();

        public DbSet<Section> Sections => Set<Section>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuramos las tablas de identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(c => c.Sections).WithOne(s => s.Course).HasForeignKey(s => s.CourseId);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(s => s.Lessons).WithOne(l => l.Section).HasForeignKey(l => l.SectionId);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
