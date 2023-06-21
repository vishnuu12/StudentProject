using StudentProject.Models;

namespace StudentProject.Repository.Interface
{
    public interface IMarksRepository
    {
        Task<Marks> GetMarksById(int studentID);
        Task AddMarks(Marks mark);
        Task UpdateMarks(Marks mark);
    }
}
