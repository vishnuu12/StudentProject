using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;
using StudentProject.Repository.Interface;
using StudentProject.Service.Interface;

namespace StudentProject.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper mapper;
        private IStudentRepository studentRepository;

        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            this.mapper = mapper;
            this.studentRepository = studentRepository;
        }

        /// <summary>
        /// Get All Students List by using Dto Objects
        /// </summary>
        /// <returns></returns>
        public List<StudentVM> GetStudents()
        {
            var students = studentRepository.GetAll();
            List<StudentVM> studentList = new List<StudentVM>();
            foreach(var student in students)
            {
                StudentVM studentVM = mapper.Map<StudentVM>(student);
                this.mapper.Map<Marks,
                    StudentVM>(student.Marks.FirstOrDefault(), studentVM);
                studentList.Add(studentVM);

            }
            return studentList;
        }

        /// <summary>
        /// Get Specific Student Record by using Dto Objects 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentVM> GetStudentById(int id)
        {
            var student = await this.studentRepository.GetStudentById(id);

            StudentVM studentVM = mapper.Map<StudentVM>(student);
            this.mapper.Map<Marks,
                StudentVM>(student.Marks.FirstOrDefault(), studentVM);

            return studentVM;
        }

        /// <summary>
        /// Student Creation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddStudent(StudentVM student)
        {

            var item = mapper.Map<Student>(student);
            await studentRepository.AddStudent(item);
            return item.Id;
        }

        /// <summary>
        /// Student Details Updation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateStudent(StudentVM student)
        {

            var item = mapper.Map<Student>(student);
            await studentRepository.UpdateStudent(item);
        }

    }
}
