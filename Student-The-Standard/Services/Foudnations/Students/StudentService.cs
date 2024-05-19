using Student_The_Standard.Brokers.DateTimes;
using Student_The_Standard.Brokers.Loggings;
using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Models.Students;
using System.Threading.Tasks;

namespace Student_The_Standard.Services.Foudnations.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public StudentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public async ValueTask<Student> AddStudentAsync(Student student) =>
            await this.storageBroker.InsertStudentAsync(student);
    }
}
