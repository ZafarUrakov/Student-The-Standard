using Student_The_Standard.Models.Students;
using Student_The_Standard.Models.Students.Exceptions;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xeptions;

namespace Student_The_Standard.Services.Foudnations.Students
{
    public partial class StudentService
    {
        private delegate ValueTask<Student> ReturningStudentFunction();

        private async ValueTask<Student> TryCatch(ReturningStudentFunction returningStudentFunction)
        {
            try
            {
                return await returningStudentFunction();
            }
            catch (NullStudentException nullStudentException)
            {
                throw CreateAndLogStudentValidationExceprion(nullStudentException);
            }
            catch (InvalidStudentException invalidStudentException)
            {
                throw CreateAndLogStudentValidationExceprion(invalidStudentException);
            }
        }

        private StudentValidationException CreateAndLogStudentValidationExceprion(Xeption innerException)
        {
            var studentValidationException = new StudentValidationException(
                message: "Student validation error occured, fix the errors and try again.",
                innerException: innerException);

            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
    }
}
