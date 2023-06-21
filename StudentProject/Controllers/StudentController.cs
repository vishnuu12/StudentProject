using Microsoft.AspNetCore.Mvc;
using StudentProject.Dto;
using StudentProject.Service.Interface;

namespace StudentProject.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;
        private IMarksService marksService;
        public StudentController(IStudentService studentService, IMarksService marksService)
        {
            this.studentService = studentService;
            this.marksService = marksService;
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
            if (studentId == 0)
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
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditStudent(StudentVM studentData)
        {
            if (ModelState.IsValid)
            {

                if (studentData.StudentId != 0)
                {
                    StudentVM? student = await this.studentService.GetStudentById(studentData.StudentId);
                    if (student == null)
                    {
                        throw new Exception($"Invalid !!");
                    }
                    else
                    {
                        await this.studentService.UpdateStudent(studentData);
                    }
                }
                else
                {
                    studentData.StudentId = await this.studentService.AddStudent(studentData);
                }
            }
            else 
            {
                throw new Exception($"Invalid !!");
            }

            await AddOrEditMark(studentData);

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// Creation or Updation Operation
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentData"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditMark(StudentVM studentData)
        {
            if (ModelState.IsValid)
            {

                if (studentData.MarksId != 0)
                {
                    StudentVM? student = await this.marksService.GetMarksById(studentData.MarksId);
                    if (student == null)
                    {
                        throw new Exception($"Invalid !!");
                    }
                    else
                    {
                        await this.marksService.UpdateMarks(studentData);
                    }
                }
                else
                {
                    await this.marksService.AddMarks(studentData);
                }
            }
            else
            {
                throw new Exception($"Invalid !!");
            }

            return View(studentData);
        }
    }
}
