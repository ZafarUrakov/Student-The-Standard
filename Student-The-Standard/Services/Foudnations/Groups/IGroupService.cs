using System.Threading.Tasks;
using Student_The_Standard.Models.Groups;

namespace Student_The_Standard.Services.Foudnations.Groups
{
    public interface IGroupService
    {
        ValueTask<Group> AddGroupAsync(Group group);
    }
}
