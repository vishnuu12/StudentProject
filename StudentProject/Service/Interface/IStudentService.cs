using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Service.Interface
{
    public interface IStudentService
    {
        List<StudentDto> GetStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<int> AddStudent(StudentDto student);
        Task<int> AddMark(StudentDto student);
        Task UpdateStudent(StudentDto student);
        Task UpdateMark(StudentDto student);

    }
}
