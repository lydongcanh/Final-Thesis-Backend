using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FinalThesisBackend.Core.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public bool Equals([AllowNull] Address other)
        {
            return other != null &&
                   Number == other.Number &&
                   Street == other.Street &&
                   District == other.District &&
                   City == other.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, Street, District, City);
        }

        public static bool operator == (Address left, Address right)
        {
            return EqualityComparer<Address>.Default.Equals(left, right);
        }

        public static bool operator != (Address left, Address right)
        {
            return !(left == right);
        }
    }
}
