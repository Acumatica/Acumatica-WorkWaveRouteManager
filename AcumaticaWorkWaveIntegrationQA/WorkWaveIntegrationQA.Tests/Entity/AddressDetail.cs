using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class AddressDetail : IEquatable<AddressDetail>
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AddressDetail);
        }

        public bool Equals(AddressDetail other)
        {
            return other != null 
                   && (string.IsNullOrEmpty(AddressLine1) ? string.IsNullOrEmpty(other.AddressLine1) :
                       (AddressLine1 == other.AddressLine1))
                   && (string.IsNullOrEmpty(AddressLine2) ? string.IsNullOrEmpty(other.AddressLine2) :
                       (AddressLine2 == other.AddressLine2))
                   && (string.IsNullOrEmpty(City) ? string.IsNullOrEmpty(other.City) :
                       (City == other.City))
                   && (string.IsNullOrEmpty(Country.Trim()) ? string.IsNullOrEmpty(other.Country.Trim()) :
                       (Country.Trim() == other.Country.Trim()))
                   && (string.IsNullOrEmpty(State.Trim()) ? string.IsNullOrEmpty(other.State.Trim()) :
                       (State.Trim() == other.State.Trim()))
                   && (string.IsNullOrEmpty(PostalCode.Trim()) ? string.IsNullOrEmpty(other.PostalCode.Trim()) :
                       (PostalCode.Trim() == other.PostalCode.Trim()));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AddressLine1, AddressLine2, City, Country, State, PostalCode);
        }

        public override string ToString()
        {
            return $"Address Detail: AddressLine1: {AddressLine1}, AddressLine2: {AddressLine2}, City: {City}, Country: {Country}, " +
                   $"State: {State}, Postal Code: {PostalCode}";
        }
    }
}
