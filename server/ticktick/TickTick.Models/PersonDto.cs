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
        public static Person ConvertToModel(PersonDto person)
        {
            var adresses = new List<Location>();
            if (person.Adresses != null)
            {
                foreach (var l in person.Adresses)
                {
                    adresses.Add(LocationDto.ConvertToModel(l)); ;
                }
            }

            Person convertedPerson = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Email = person.Email,
                DoB = person.DoB,
                Adresses = adresses
            };
            convertedPerson.CreatePublicId();

            return convertedPerson;
        }
    }
}
