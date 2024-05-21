using Xeptions;

namespace Student_The_Standard.Models.Students.Exceptions
{
    public class NullStudentException : Xeption
    {
        public NullStudentException(string message)
            :base(message)
        { }
    }
}
