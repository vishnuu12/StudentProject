using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentProject.Dto;
using StudentProject.Models;
using StudentProject.Repository.Interface;
using StudentProject.Service.Interface;

namespace StudentProject.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Get Student Total Records
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var result = studentService.GetStudents();
            return View(result);
        }

        /// <summary>
        /// Get Student Specific Records
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }
            var result = await studentService.GetStudentById(studentId);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }


        /// <summary>
        /// Checking the Operation for Creation or Updation
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEdit(int studentId)
        {
            ViewBag.PageName = studentId == 0 ? "Create Student" : "Edit Student";
            ViewBag.IsEdit = studentId == 0 ? false : true;
            if (studentId == 0)
            {
                return View();
            }
            else
            {
                var student = await this.studentService.GetStudentById(studentId);

                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
        }
        /// <summary>
        /// Creation or Updation Operation
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentData"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> Add([FromBody] int studentId, 
            [Bind("Id,StudentName,Class,DateOfBirth,Tamil,English,Maths")] StudentDto studentData)
        {
            ViewBag.PageName = studentId == 0 ? "Create Student" : "Edit Student";
            ViewBag.IsEdit = studentId == 0 ? false : true;

            bool IsStudentExist = false;

            StudentDto? student = await this.studentService.GetStudentById(studentId);

            if (student != null)
            {
                IsStudentExist = true;
            }
            else
            {
                student = new StudentDto();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    student.Id = studentData.Id;
                    student.StudentName = studentData.StudentName;
                    student.Class = studentData.Class;
                    student.DateOfBirth = studentData.DateOfBirth;
                    student.Marks.FirstOrDefault().Tamil = studentData.Marks.FirstOrDefault().Tamil;
                    student.Marks.FirstOrDefault().English = studentData.Marks.FirstOrDefault().English;
                    student.Marks.FirstOrDefault().Maths = studentData.Marks.FirstOrDefault().Maths;

                    if (IsStudentExist)
                    {
                        await this.studentService.UpdateStudent(student);
                        student.Marks.FirstOrDefault().StudentId = studentData.Marks.FirstOrDefault().StudentId;
                        await this.studentService.UpdateMark(student);
                    }
                    else
                    {
                        studentId = await this.studentService.AddStudent(student);
                        student.Marks.FirstOrDefault().StudentId = studentId;
                        await this.studentService.AddMark(student);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Invalid !!");
                }
                return RedirectToAction(nameof(Index));
            }

            return View(studentData);
        }
    }
}
