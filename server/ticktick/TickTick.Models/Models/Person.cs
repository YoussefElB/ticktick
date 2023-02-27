using System;

namespace TickTick.Models.Models
{
    public class Person : BaseAuditableEntity, IEquatable<Person>
    {
        public Guid PublicId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsDeleted { get; private set; }

        public Person() { }
        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        /*
        public void Update(PersonDto dto)
        {
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.MiddleName = dto.MiddleName;
            this.DateOfBirth = dto.DateOfBirth;
            this.DateOfDeath = dto.DateOfDeath;
            this.Email = dto.Email;
        }
        **/
        public override string? ToString()
        {
            return $"{FirstName} {LastName} {Email}";
        }

        public bool Equals(Person? other)
        {
            if (!string.IsNullOrEmpty(SocialSecurityNumber) && !string.IsNullOrEmpty(other?.SocialSecurityNumber))
            {
                return SocialSecurityNumber == other.SocialSecurityNumber;
            }
            else
            {
                return PublicId == other?.PublicId;
            }
        }
        public void CreatePublicId()
        {
            PublicId = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }
    }
}
