namespace StudentRegistrationWebAPIWithInMemory.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public string Email { get; set; } = "";

        public int PhoneNumber { get; set; }

        public Guid StudentId { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
