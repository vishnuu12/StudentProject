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
        public async Task AddStudent(StudentDto student)
        {
            await this.dbContext.Set<StudentDto>().AddAsync(student);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// AddMark method for creating student mark records
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task AddMark(StudentDto student)
        {
            MarkDto mark = new MarkDto();
            mark.StudentId = student.Marks.First().StudentId;
            mark.Tamil = student.Marks.First().Tamil;
            mark.English = student.Marks.First().English;
            mark.Maths = student.Marks.First().Maths;
            await this.dbContext.Set<MarkDto>().AddAsync(mark);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// UpdateStudent method for updating student datas
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateStudent(StudentDto student)
        {
            dbContext.Entry(student).State = EntityState.Modified;
        }

        /// <summary>
        /// UpdateMark method for updating student mark datas
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateMark(StudentDto student)
        {
            MarkDto mark = new MarkDto();
            mark.StudentId = student.Marks.First().StudentId;
            mark.Tamil = student.Marks.First().Tamil;
            mark.English = student.Marks.First().English;
            mark.Maths = student.Marks.First().Maths;
            dbContext.Entry(mark).State = EntityState.Modified;
        }

    }
}
