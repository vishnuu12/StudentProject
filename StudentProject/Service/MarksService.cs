using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;
using StudentProject.Repository.Interface;
using StudentProject.Service.Interface;

namespace StudentProject.Service
{
    public class MarksService : IMarksService
    {
        private readonly IMapper mapper;
        private IMarksRepository marksRepository;

        public MarksService(IMapper mapper, IMarksRepository marksRepository)
        {
            this.mapper = mapper;
            this.marksRepository = marksRepository;
        }

        /// <summary>
        /// Get Specific Student Record by using Dto Objects 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentVM> GetMarksById(int id)
        {
            var marks = await this.marksRepository.GetMarksById(id);
            return mapper.Map<StudentVM>(marks);
        }

        /// <summary>
        /// Student Mark Creation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddMarks(StudentVM student)
        {

            var item = mapper.Map<Marks>(student);
            await marksRepository.AddMarks(item);
            return item.Id;
        }

        /// <summary>
        /// Student Mark Details Updation Operation
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task UpdateMarks(StudentVM student)
        {

            var item = mapper.Map<Marks>(student);
            await marksRepository.UpdateMarks(item);
        }
    }
}
