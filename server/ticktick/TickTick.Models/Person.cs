using System;

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

        public Person() { }
        public Person(string firstName, string lastName, string email, List<Location> locations)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adresses = locations;
        }
        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }

        public void AddLocation(Location location) {
            if (Adresses == null) { }
            {
                this.Adresses = new List<Location>();
            }
            this.Adresses.Add(location);
        }
        public void RemoveLocation(Location location)
        {
            if (Adresses != null)
            {
                Adresses.Remove(location);
            }
        }

        public void Update(PersonDto dto)
        {
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.MiddleName = dto.MiddleName;
            this.DoB = dto.DoB;
            this.Email = dto.Email;
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

        public PersonDto ConvertToDto()
        {
            return new PersonDto()
            {
                PublicId = this.PublicId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                MiddleName = this.MiddleName,
                DoB = this.DoB,
                Email = this.Email
            };
        }
        public void CreatePublicId()
        {
            this.PublicId = Guid.NewGuid();
        }
    }
}
