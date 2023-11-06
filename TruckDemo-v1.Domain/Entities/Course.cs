using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Domain.Entities;
using TruckDemo_v1.Domain.ValueObject;

namespace TruckDemo_v1.Domain.ValueObject
{
    public class Course
    {
        public Course(string title, HtmlContent content, DateTime createdAt, string? subtitle, DateTime? lastUpdatedAt, DateTime? publishedAt)
        {
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            Subtitle = subtitle;
            LastUpdatedAt = lastUpdatedAt;
            PublishedAt = publishedAt;
            Sections = new HashSet<Section>();

        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public HtmlContent Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public ICollection<Section> Sections { get; set; }

    }
}
