namespace TickTick.Models
{
    public class Person : BaseAuditableEntity, IEquatable<Person>
    {
        public Guid PublicId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DoB { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Location> Adresses { get; set; }
        public bool IsDeleted { get; private set; }

        public Person(string firstName, string lastName, string email, List<Location> locations)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adresses = locations;
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }
        public void Update()
        {
            return;
        }

        public override string? ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Email}";
        }

        public bool Equals(Person? other)
        {
            if (!string.IsNullOrEmpty(this.SocialSecurityNumber) && !string.IsNullOrEmpty(other?.SocialSecurityNumber))
            {
                return this.SocialSecurityNumber == other.SocialSecurityNumber;
            }
            else
            {
                return this.PublicId == other?.PublicId;
            }
        }

        public static PersonDto ConvertToDto(Person person)
        {
            var adresses = new List<LocationDto>();
            foreach (var l in person.Adresses)
            {
                adresses.Add(Location.ConvertToDto(l)); ;
            }

            return new PersonDto()
            {
                PublicId = person.PublicId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Email = person.Email,
                DoB = person.DoB,
                Adresses =  adresses
            };
        }
    }
}
