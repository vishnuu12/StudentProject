using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Repository.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Task<Student> GetStudentById(int studentID);
        Task AddStudent(StudentDto student);
        Task AddMark(StudentDto student);
        Task UpdateStudent(StudentDto student);
        Task UpdateMark(StudentDto student);
    }
}
