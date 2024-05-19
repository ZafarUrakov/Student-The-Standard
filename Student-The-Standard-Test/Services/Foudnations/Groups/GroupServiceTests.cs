using System.Linq.Expressions;
using Moq;
using Student_The_Standard.Brokers.DateTimes;
using Student_The_Standard.Brokers.Loggings;
using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Models.Groups;
using Student_The_Standard.Services.Foudnations.Groups;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Student_The_Standard_Test.Services.Foudnations.Groups
{
    public partial class GroupServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly GroupService groupService;

        public GroupServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.groupService = new GroupService(
                storageBroker: this.storageBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static Group CreateRandomGroup(DateTimeOffset date) =>
            CreateGroupFiller(date).Create();

        private static Filler<Group> CreateGroupFiller(DateTimeOffset date)
        {
            var filler = new Filler<Group>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
