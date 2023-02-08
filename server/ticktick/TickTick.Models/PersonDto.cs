using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models
{
    public class PersonDto
    {
        public Guid PublicId { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime? DoB { get; set; }
        public List<LocationDto> Adresses { get; set; }
    }
}
