﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models
{
    public class LocationDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string Nr { get; set; }

        public static Location ConvertToModel(LocationDto loc)
        {
            return new Location(
                loc.Street,
                loc.City,
                loc.Zipcode,
                loc.Country,
                loc.Nr);
        }
    }
}
