using FluentAssertions;
using Moq;
using Student_The_Standard.Models.Students;
using Student_The_Standard.Models.Students.Exceptions;

namespace Student_The_Standard_Test.Services.Foudnations.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        private async Task ShouldThrowValidationExceptionOnAddAndLogItAsync()
        {
            // given
            Student nullStudent = null;

            var nullStudentException = new NullStudentException(
                message: "Student is null.");

            var expectedStudentValidationException = new StudentValidationException(
                message: "Student validation error occured, fix the errors and try again.",
                innerException: nullStudentException);

            // when
            ValueTask<Student> addStudentTask =
                this.studentService.AddStudentAsync(nullStudent);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            // then
            actualStudentValidationException.Should()
                .BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentValidationException))), 
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), 
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        private async Task ShouldThrowValidationExceptionOnAddIGuestIsInvalidAndLogItAsync(
            string invalidText)
        {
            // given 
            var invalidStudent = new Student
            {
                Name = invalidText
            };

            var invalidStudentException = new InvalidStudentException(
                message: "Student is invalid, fix the errors and try again.");

            invalidStudentException.AddData(
                key: nameof(Student.Id),
                values: "Id is required");
            
            invalidStudentException.AddData(
                key: nameof(Student.Name),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.CreatedDate),
                values: "Value is required");

            invalidStudentException.AddData(
                key: nameof(Student.UpdatedDate),
                values: "Value is required");

            var expectedStudentValidationException = new StudentValidationException(
                message: "Student validation error occured, fix the errors and try again.",
                innerException: invalidStudentException);

            // when
            ValueTask<Student> addStudentTask =
                this.studentService.AddStudentAsync(invalidStudent);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            // then
            actualStudentValidationException.Should()
                .BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
