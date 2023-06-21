using StudentProject.Dto;

namespace StudentProject.Service.Interface
{
    public interface IStudentService
    {
        List<StudentVM> GetStudents();
        Task<StudentVM> GetStudentById(int id);
        Task<int> AddStudent(StudentVM student);
        Task UpdateStudent(StudentVM student);

    }
}
