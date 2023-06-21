using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Repository.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Task<Student> GetStudentById(int studentID);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
    }
}
