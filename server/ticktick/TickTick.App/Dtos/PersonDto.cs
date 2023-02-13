namespace TickTick.Models
{
    public class PersonDto
    {
        public Guid PublicId { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }

    public static class PersonExtensions
    {
        public static Person ConvertToModel(PersonDto person)
        {
            Person convertedPerson = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                DateOfDeath = person.DateOfDeath
            };
            convertedPerson.CreatePublicId();

            return convertedPerson;
        }

        public static PersonDto ConvertToDto(Person person)
        {

            return new PersonDto()
            {
                PublicId = person.PublicId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
            };
        }
    }
}
