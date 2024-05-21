using System;
using Xeptions;

namespace Student_The_Standard.Models.Students.Exceptions
{
    public class StudentValidationException : Xeption
    {
        public StudentValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
