using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDemo_v1.Domain.ValueObject
{
    public class HtmlContent : IEquatable<HtmlContent>
    {
        public string Value { get; }

        public HtmlContent(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("HTML content cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public bool Equals(HtmlContent? other)
        {
            if (other is null)
            {
                return false;
            }

            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((HtmlContent)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
