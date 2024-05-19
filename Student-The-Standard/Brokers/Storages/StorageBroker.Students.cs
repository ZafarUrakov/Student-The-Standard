using Microsoft.EntityFrameworkCore;
using Student_The_Standard.Models.Students;
using System.Threading.Tasks;

namespace Student_The_Standard.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> MyProperty { get; set; }

        public async ValueTask<Student> InsertStudentAsync(Student student) =>
            await InsertAsync(student);
    }
}
