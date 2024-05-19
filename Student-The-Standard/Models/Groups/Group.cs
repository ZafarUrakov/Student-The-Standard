using System;

namespace Student_The_Standard.Models.Groups
{
    public class Group
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public GroupStatus Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        
    }
}
