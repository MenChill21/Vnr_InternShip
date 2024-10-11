using ManageCourses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace ManageCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly VnrInternShipContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, VnrInternShipContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var subjects = _context.MonHocs.ToList();
            if (id != null)
            {
                var nameCourse = _context.KhoaHocs.Find(id);
                if (nameCourse != null)
                {
                    TempData["NameCourse"] = nameCourse.TenKhoaHoc;
                }
                subjects = _context.MonHocs.Where(x => x.KhoaHocId == id).ToList();
            }
            var couresVm = new CourseVm
            {
                Subjects = subjects,
                Courses = _context.KhoaHocs.ToList(),
            };
            return View(couresVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
