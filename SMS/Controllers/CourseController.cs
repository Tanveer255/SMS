using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.BLL.Interfaces;
using SMS.Models.Data;
using SMS.Models.Data.Models;
using SMS.Models.DTO;

namespace SMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly ICourseService CourseService;
        private readonly ApplicationDbContext context;

        public CourseController(ICourseService CourseService, ILogger<CourseController> logger,ApplicationDbContext context)
        {
            this.CourseService = CourseService;
            this.logger = logger;
            this.context = context;
        }

    
        // GET: CourseController
        public ActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        public ActionResult GetCourseList()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                logger.LogInformation("Adding Course.");
                CourseService.Add(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
