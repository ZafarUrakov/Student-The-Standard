using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Student_The_Standard.Models.Students;

namespace Student_The_Standard_Test.Services.Foudnations.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        private async Task ShouldAddStudentAsync()
        {
            // given
            //DateTimeOffset randomDateTime = GetRandomDateTimeOffset();
            Student randomStudent = CreateRandomStudent(GetRandomDateTimeOffset());
            Student inputStudent = randomStudent;
            Student persistedStudent = inputStudent;
            Student expectedStudent = inputStudent.DeepClone();

            //this.dateTimeBrokerMock.Setup(broker =>
            //    broker.GetDateTimeOffset())
            //        .Returns(randomDateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(inputStudent))
                    .ReturnsAsync(persistedStudent);
            // when
            Student actualStudent = 
                await this.studentService.AddStudentAsync(inputStudent);

            // then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            //this.dateTimeBrokerMock.Verify(broker =>
            //    broker.GetDateTimeOffset(), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(inputStudent), Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
