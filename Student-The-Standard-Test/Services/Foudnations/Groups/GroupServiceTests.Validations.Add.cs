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
                    message: "Group validation error occurred, fix the errors and try again.",
                    innerException: nullGroupException);

            // when
            ValueTask<Group> addGroupTask = this.groupService.AddGroupAsync(nullGroup);

            GroupValidationException actualGroupValidationException =
                    await Assert.ThrowsAsync<GroupValidationException>(addGroupTask.AsTask);

            // then
            actualGroupValidationException.Should().BeEquivalentTo(expectedGroupValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                        expectedGroupValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsInvalid(
            string invalidString)
        {
            // given
            var invalidGroup = new Group
            {
                Name = invalidString
            };

            var invalidGroupException = new InvalidGroupException();

            invalidGroupException.AddData(
                key: nameof(Group.Id),
                values: "Id is required");

            invalidGroupException.AddData(
                key: nameof(Group.Name),
                values: "Text is required");

            invalidGroupException.AddData(
                key: nameof(Group.CreatedTime),
                values: "Value is required");

            invalidGroupException.AddData(
                key: nameof(Group.ModifiedTime),
                values: "Value is required");

            var expectedGroupValidationException =
                new GroupValidationException(
                    message: "Group validation error occurred, fix the errors and try again.",
                    innerException: invalidGroupException);

            // when
            ValueTask<Group> addGroupTask = this.groupService.AddGroupAsync(invalidGroup);

            GroupValidationException actualGroupValidationException =
                    await Assert.ThrowsAsync<GroupValidationException>(addGroupTask.AsTask);

            // then
            actualGroupValidationException.Should()
                .BeEquivalentTo(expectedGroupValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                        expectedGroupValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
