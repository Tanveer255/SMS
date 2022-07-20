using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.BLL.Interfaces;
using SMS.Models.Data;
using SMS.Models.DTO;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;
        private readonly ILogger<StudentController>? logger;
        private readonly ApplicationDbContext context;

        public StudentController(ILogger<StudentController>logger,IStudentService studentService, ApplicationDbContext context)
        {
            this.logger = logger;
            this.studentService = studentService;
            this.context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }
        // GET: StudentController List
        public ActionResult StudentList()
        {
            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDTO studentDTO)
        {
            try
            {
                var student = studentDTO.MapDtoToModel(studentDTO);
                if (studentDTO.ID==Guid.Empty)
                {
                    student.CreateDate = DateTime.Now;
                    student = studentService.Add(student).Result;
                }
                return View(student);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                return NotFound();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
