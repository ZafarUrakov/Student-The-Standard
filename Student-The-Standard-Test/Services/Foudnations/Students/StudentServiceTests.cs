using Moq;
using Student_The_Standard.Brokers.DateTimes;
using Student_The_Standard.Brokers.Loggings;
using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Models.Students;
using Student_The_Standard.Services.Foudnations.Students;
using Tynamix.ObjectFiller;

namespace Student_The_Standard_Test.Services.Foudnations.Students
{
    public partial class StudentServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IStudentService studentService;

        public StudentServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.studentService =
                new StudentService(
                    storageBroker: this.storageBrokerMock.Object,
                    dateTimeBroker: this.dateTimeBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Filler<Student> CreateStudentFiller(DateTimeOffset dateTimeOffset)
        {
            var filler = new Filler<Student>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dateTimeOffset);

            return filler;
        }

        private static Student CreateRandomStudent(DateTimeOffset dateTimeOffse) =>
            CreateStudentFiller(dateTimeOffse).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
    }
}
