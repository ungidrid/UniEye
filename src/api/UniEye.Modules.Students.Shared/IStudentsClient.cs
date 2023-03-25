using Refit;
using UniEye.Modules.Students.Shared.DTO;

namespace UniEye.Modules.Students.Shared
{
    public interface IStudentsClient
    {
        [Get("/student/{id}")]
        Task<StudentDto> GetStudentById(int id);
    }
}
