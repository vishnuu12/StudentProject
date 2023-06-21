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
        public List<StudentDto> GetStudents()
        {
            var students = studentRepository.GetAll();
            return mapper.Map<List<StudentDto>>(students);
        }

        /// <summary>
        /// Get Specific Student Record by using Dto Objects 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDto> GetStudentById(int id)
        {
            var students = await this.studentRepository.GetStudentById(id);
            return mapper.Map<StudentDto>(students);
        }

        /// <summary>
        /// Student Creation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddStudent(StudentDto student)
        {

            var item = mapper.Map<StudentDto>(student);
            await studentRepository.AddStudent(item);
            return item.Id;
        }

        /// <summary>
        /// Student Mark Creation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddMark(StudentDto student)
        {

            var item = mapper.Map<StudentDto>(student);
            await studentRepository.AddMark(item);
            return item.Id;
        }

        /// <summary>
        /// Student Details Updation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateStudent(StudentDto student)
        {

            var item = mapper.Map<StudentDto>(student);
            await studentRepository.UpdateStudent(item);
        }

        /// <summary>
        /// Student Mark Details Updation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateMark(StudentDto student)
        {

            var item = mapper.Map<StudentDto>(student);
            await studentRepository.UpdateMark(item);
        }

    }
}
