using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Student_The_Standard.Models.Groups;

namespace Student_The_Standard_Test.Services.Foudnations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldAddGroupAsync()
        {
            // given
            var randomDate = GetRandomDateTimeOffset();
            Group randomGroup = CreateRandomGroup(randomDate);
            Group inputGroup = randomGroup;
            Group persistedGroup = inputGroup;
            Group expectedGroup = persistedGroup.DeepClone();

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetDateTimeOffset())
                    .Returns(randomDate);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(inputGroup))
                    .ReturnsAsync(persistedGroup);

            // when
            Group actualGroup = await this.groupService.AddGroupAsync(persistedGroup);

            // then
            actualGroup.Should().BeEquivalentTo(expectedGroup);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetDateTimeOffset(), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGroupAsync(inputGroup), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
