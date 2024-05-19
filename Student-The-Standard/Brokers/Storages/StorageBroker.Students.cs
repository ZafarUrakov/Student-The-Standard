using Microsoft.EntityFrameworkCore;
using Student_The_Standard.Models.Students;

namespace Student_The_Standard.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> MyProperty { get; set; }
    }
}
