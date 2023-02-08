using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models
{
    public enum LocationType
    {
        PRIMARY = 0,
        WORK = 1,
        HOME = 2,
        OTHER = 3
    }

    public sealed class Location : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string Nr { get; set; }
        public LocationType MyProperty { get; set; } = LocationType.PRIMARY;

        public Location(
        string street,
        string city,
        string zipcode,
        string country,
        string nr,
        string state)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
            Country = country;
            Nr = nr;
            State = state;
        }

        public Location(
            string street,
            string city,
            string zipcode,
            string country,
            string nr)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
            Country = country;
            Nr = nr;
        }

        public override string? ToString()
        {
            return $"{this.Street} {this.Nr} {this.City} {this.Country}";
        }
    }
}
