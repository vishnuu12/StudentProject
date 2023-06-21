using Microsoft.EntityFrameworkCore;
using StudentProject.Models;
using StudentProject.Repository.Interface;

namespace StudentProject.Repository
{
    public class MarksRepository : IMarksRepository
    {
        private readonly SchoolDbContext dbContext;
        public MarksRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetMarksById method for fetching specific Marks Datas
        /// </summary>
        /// <param name="marksId"></param>
        /// <returns></returns>
        public async Task<Marks> GetMarksById(int marksId)
        {
            var result = await this.dbContext.Marks.FirstOrDefaultAsync(m => m.Id == marksId); ;
            if (result != null)
            {
                dbContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        /// <summary>
        /// AddMark method for creating student mark records
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public async Task AddMarks(Marks mark)
        {
            await this.dbContext.Set<Marks>().AddAsync(mark);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// UpdateMark method for updating student mark datas
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public async Task UpdateMarks(Marks mark)
        {
            dbContext.Entry(mark).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
