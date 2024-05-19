using System.Threading.Tasks;
using Student_The_Standard.Brokers.DateTimes;
using Student_The_Standard.Brokers.Loggings;
using Student_The_Standard.Brokers.Storages;
using Student_The_Standard.Models.Groups;

namespace Student_The_Standard.Services.Foudnations.Groups
{
    public class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public GroupService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Group> AddGroupAsync(Group group)
        {
            var currentDateTime = this.dateTimeBroker.GetDateTimeOffset();

            return await this.storageBroker.InsertGroupAsync(group);
        }
    }
}
