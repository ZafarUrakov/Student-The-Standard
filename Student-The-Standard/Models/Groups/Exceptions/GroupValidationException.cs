using Xeptions;

namespace Student_The_Standard.Models.Groups.Exceptions
{
    public class GroupValidationException : Xeption
    {
        public GroupValidationException(string message, Xeption innerException) 
            : base(message, innerException)
        { }
    }
}
