using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.Data;
using TruckDemo_v1.Domain.Entities;
using TruckDemo_v1.Domain.ValueObject;

namespace TruckDemo_v1.Infraestructure.Data
{
    public class TruckDemoContext : DbContext, ITruckDemoContext
    {
        public TruckDemoContext(DbContextOptions<TruckDemoContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Lesson> Lessons => Set<Lesson>();

        public DbSet<Section> Sections => Set<Section>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(o => o.HasKey(o => o.Id));
            modelBuilder.Entity<Lesson>(o => o.HasKey(o => o.Id));
            modelBuilder.Entity<Section>(o => o.HasKey(o => o.Id));

            modelBuilder.Entity<Course>().HasMany(S => S.Sections);
            modelBuilder.Entity<Section>().HasMany(L => L.Lessons);
            modelBuilder.Entity<Lesson>().HasIndex(S => S.SectionId);
        }
    }
}
