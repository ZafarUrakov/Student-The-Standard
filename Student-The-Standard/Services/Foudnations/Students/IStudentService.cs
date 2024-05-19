using Student_The_Standard.Models.Students;
using System.Threading.Tasks;

namespace Student_The_Standard.Services.Foudnations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> AddStudentAsync(Student student);
    }
}
