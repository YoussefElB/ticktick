namespace TickTick.Domain.Model
{
    public class Person
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? PhoneNumber { get; set; }

        public Person(DateTime dateOfBirth,
            string firstName,
            string lastName,
            string? middleName,
            string email,
            string? socialSecurityNumber,
            DateTime? dateOfDeath,
            string? phoneNumber)
        {
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Email = email;
            SocialSecurityNumber = socialSecurityNumber;
            DateOfDeath = dateOfDeath;
            PhoneNumber = phoneNumber;
        }
    }
}