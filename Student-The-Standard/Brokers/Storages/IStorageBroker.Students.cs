using Student_The_Standard.Models.Students;
using System.Threading.Tasks;

namespace Student_The_Standard.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Student> InsertStudentAsync(Student student);
    }
}
