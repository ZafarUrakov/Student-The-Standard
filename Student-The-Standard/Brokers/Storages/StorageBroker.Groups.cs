using System.Threading.Tasks;
using Student_The_Standard.Models.Groups;

namespace Student_The_Standard.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Group> InsertGroupAsync(Group group) =>
            await InsertAsync(group);
    }
}
