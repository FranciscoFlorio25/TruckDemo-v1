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

        }
    }
}
