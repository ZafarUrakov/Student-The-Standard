using FluentAssertions;
using Moq;
using Student_The_Standard.Models.Groups;
using Student_The_Standard.Models.Groups.Exceptions;

namespace Student_The_Standard_Test.Services.Foudnations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGroupIsNull()
        {
            // given
            Group nullGroup = null;

            var nullGroupException = new NullGroupException(
                "Group is null.");

            var expectedGroupValidationException =
                new GroupValidationException(
                    message: "Group validation error occured, fix the errors and try again.",
                    innerException: nullGroupException);

            // when
            ValueTask<Group> addGroupTask = this.groupService.AddGroupAsync(nullGroup);

            GroupValidationException actualGroupValidationException =
                    await Assert.ThrowsAsync<GroupValidationException>(addGroupTask.AsTask);

            // then
            actualGroupValidationException.Should().BeEquivalentTo(expectedGroupValidationException);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
