﻿namespace OnlineAttendanceStudent.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
    }
}
