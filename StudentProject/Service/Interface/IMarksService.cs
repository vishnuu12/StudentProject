using StudentProject.Dto;

namespace StudentProject.Service.Interface
{
    public interface IMarksService
    {
        Task<StudentVM> GetMarksById(int id);
        Task<int> AddMarks(StudentVM student);
        Task UpdateMarks(StudentVM student);
    }
}
