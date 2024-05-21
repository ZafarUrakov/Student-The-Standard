using Xeptions;

namespace Student_The_Standard.Models.Students.Exceptions
{
    public class InvalidStudentException : Xeption
    {
        public InvalidStudentException(string message)
            : base(message)
        { }
    }
}
