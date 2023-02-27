using TickTick.Models.Models;

namespace TickTick.App.Dtos
{
    public class AddPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public static Person ConvertToModel(AddPersonDto person)
        {

            Person convertedPerson = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
            };
            convertedPerson.CreatePublicId();

            return convertedPerson;
        }
    }
}
