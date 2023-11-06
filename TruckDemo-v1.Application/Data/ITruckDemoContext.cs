using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Domain.Entities;
using TruckDemo_v1.Domain.ValueObject;

namespace TruckDemo_v1.Application.Data
{
    public interface ITruckDemoContext
    {
        DbSet<Course> Courses { get; }

        DbSet<Lesson> Lessons { get; }

        DbSet<Section> Sections { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
