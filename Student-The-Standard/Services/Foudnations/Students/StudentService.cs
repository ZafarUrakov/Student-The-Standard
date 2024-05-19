using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Models.Students;
using System.Threading.Tasks;

namespace Student_The_Standard.Services.Foudnations.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;

        public StudentService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public ValueTask<Student> AddStudentAsync(Student student) =>
            throw new System.NotImplementedException();
    }
}
