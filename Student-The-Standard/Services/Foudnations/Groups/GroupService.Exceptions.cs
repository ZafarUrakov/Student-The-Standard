using System;
using System.Threading.Tasks;
using Student_The_Standard.Models.Groups;
using Student_The_Standard.Models.Groups.Exceptions;
using Xeptions;

namespace Student_The_Standard.Services.Foudnations.Groups
{
    public partial class GroupService
    {
        private delegate ValueTask<Group> ReturningGroupFunction();

        private async ValueTask<Group> TryCatch(ReturningGroupFunction returningGroupFunction)
        {
            try
            {
                return await returningGroupFunction();
            }
            catch (NullGroupException nullGroupException)
            {
                throw CreateAndLogGroupValidationException(nullGroupException);
            }
            catch(InvalidGroupException invalidGroupException)
            {
                throw CreateAndLogGroupValidationException(invalidGroupException);
            }
        }

        private Xeption CreateAndLogGroupValidationException(Xeption nullGroupException)
        {
            var groupValidationException = new GroupValidationException(
                message: "Group validation error occurred, fix the errors and try again.",
                innerException: nullGroupException);

            this.loggingBroker.LogError(groupValidationException);

            return groupValidationException;
        }
    }
}
