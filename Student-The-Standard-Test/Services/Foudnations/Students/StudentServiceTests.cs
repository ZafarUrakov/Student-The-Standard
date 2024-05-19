using Moq;
using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Services.Foudnations.Students;

namespace Student_The_Standard_Test.Services.Foudnations.Students
{
    public partial class StudentServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IStudentService studentService;

        public StudentServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.studentService =
                new StudentService(this.storageBrokerMock.Object);
        }

    }
}
