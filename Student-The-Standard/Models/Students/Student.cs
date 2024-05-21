using Student_The_Standard.Models.Groups;
using System;

namespace Student_The_Standard.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StudentType StudentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Group Group { get; set; }
        public Guid GroupId { get; set; }
    }
}
