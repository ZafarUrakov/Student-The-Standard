using Xeptions;

namespace Student_The_Standard.Models.Groups.Exceptions
{
    public class NullGroupException: Xeption
    {
        public NullGroupException(string message)
            : base(message)
        { }
    }
}
