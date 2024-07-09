﻿namespace StudentRegistrationWebAPIWithInMemory.Models
{
    public class AddStudentView
    {
        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public string Email { get; set; } = "";

        public int PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
