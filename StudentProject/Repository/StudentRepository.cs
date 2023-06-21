using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentProject.Dto;
using StudentProject.Models;
using StudentProject.Repository.Interface;

namespace StudentProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext dbContext;
        public StudentRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// GetAll method for fetching All Student Records
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAll()
        {
            var results = this.dbContext.Students.Include("Marks").ToList();
            return results;
        }

        /// <summary>
        /// GetStudentById method for fetching specific student records
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(int studentId)
        {
            var result = await this.dbContext.Students.Include("Marks").FirstOrDefaultAsync(m => m.Id == studentId); ;
            if (result != null)
            {
                dbContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        /// <summary>
        /// AddStudent method for creating student records
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task AddStudent(Student student)
        {
            await this.dbContext.Set<Student>().AddAsync(student);
            dbContext.SaveChanges();
        }


        /// <summary>
        /// UpdateStudent method for updating student datas
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateStudent(Student student)
        {
            dbContext.Entry(student).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

    }
}
