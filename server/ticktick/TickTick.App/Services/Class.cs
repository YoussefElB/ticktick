using TickTick.Models;

namespace TickTick.App.Services
{
    public class AddPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime? DoB { get; set; }
    }
}
