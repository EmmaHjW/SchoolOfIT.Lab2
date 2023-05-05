using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolOfIT.Lab2.Data;
using SchoolOfIT.Lab2.Models;


namespace SchoolOfIT.Controllers
{
    public class TeachersController : Controller
    {
        private readonly SchoolOfITContext _context;

        public TeachersController(SchoolOfITContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,FullName,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FullName,Email")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity set 'SchoolOfITContext.Teachers'  is null.");
            }
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return (_context.Teachers?.Any(e => e.TeacherId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Search(string searchString = "")
        {
            List<RelationTable> relationTables = new List<RelationTable>();
            relationTables = await _context.Relations.ToListAsync();
            var data = await (from r in _context.Relations
                              join t in _context.Teachers on r.FK_TeacherId equals t.TeacherId
                              join c in _context.Courses on r.FK_CourseId equals c.CourseId
                              where c.CourseName.Contains(searchString)
                              select new
                              {
                                  TeacherId = t.TeacherId,
                                  TeacherName = t.FullName,
                                  CourseName = c.CourseName
                              }).ToListAsync();
            List<SearchViewModel> searchViewModel = new List<SearchViewModel>();
            foreach (var item in data)
            {
                var test = new SearchViewModel
                {
                    TeacherId = item.TeacherId,
                    TeacherName = item.TeacherName,
                    CourseName = item.CourseName
                };
                searchViewModel.Add(test);
            }

            return View(searchViewModel);
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using SchoolOfIT.Lab2.Data;
//using SchoolOfIT.Lab2.Models;

//namespace SchoolOfIT.Lab2.Controllers
//{
//    public class TeachersController : Controller
//    {
//        private readonly SchoolOfITContext _context;

//        public TeachersController(SchoolOfITContext context)
//        {
//            _context = context;
//        }

//        //GET: Teachers
//        public async Task<IActionResult> Index()
//        {
//            return _context.Teachers != null ?
//                        View(await _context.Teachers.ToListAsync()) :
//                        Problem("Entity set 'SchoolOfITContext.Teachers'  is null.");
//        }
//        [HttpGet]
//        public async Task<IActionResult> Index(string searchString)
//        {
//            var teachers = _context.Teachers.Include(t => t.Relations).ThenInclude(r => r.Courses);

//            if (!string.IsNullOrEmpty(searchString))
//            {
//                teachers = teachers.Where(t => t.Relations.Any(r => r.Courses.CourseName.Contains(searchString)));
//            }

//            return View(await teachers.ToListAsync());
//        }

//        //GET: Teachers/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Teachers == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers
//                .FirstOrDefaultAsync(m => m.TeacherId == id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            return View(teacher);
//        }
//        public ActionResult Details(int id)
//        {
//            var teacher = _context.Teachers.Find(id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            var courses = _context.Courses
//                .Where(c => c.Relations.Any(r => r.Teachers.TeacherId == id))
//                .ToList();

//            ViewBag.Courses = courses;

//            return View(teacher);
//        }
//        // GET: Teachers/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Teachers/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TeacherId,FullName,Email,Address,City,DateOfBirth")] Teacher teacher)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(teacher);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(teacher);
//        }

//        // GET: Teachers/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Teachers == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers.FindAsync(id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }
//            return View(teacher);
//        }

//        // POST: Teachers/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FullName,Email,Address,City,DateOfBirth")] Teacher teacher)
//        {
//            if (id != teacher.TeacherId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(teacher);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!TeacherExists(teacher.TeacherId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(teacher);
//        }

//        // GET: Teachers/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Teachers == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers
//                .FirstOrDefaultAsync(m => m.TeacherId == id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            return View(teacher);
//        }

//        // POST: Teachers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Teachers == null)
//            {
//                return Problem("Entity set 'SchoolOfITContext.Teachers'  is null.");
//            }
//            var teacher = await _context.Teachers.FindAsync(id);
//            if (teacher != null)
//            {
//                _context.Teachers.Remove(teacher);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool TeacherExists(int id)
//        {
//          return (_context.Teachers?.Any(e => e.TeacherId == id)).GetValueOrDefault();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Index(string searchString)
//        {
//            var teachers = _context.Teachers.Where(t => t.Relations.Any(r => r.Courses.CourseName == "Programmering 1"));

//            if (!string.IsNullOrEmpty(searchString))
//            {
//                teachers = teachers.Where(t => t.FullName.Contains(searchString));
//            }

//            return View(teachers.ToList());
//        }
//        [HttpGet]
//        [ValidateAntiForgeryToken]
//        public ActionResult Search()
//        {
//            return View("Index", _context.Teachers.ToList());
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Search(string searchTerm)
//        {
//            if (string.IsNullOrEmpty(searchTerm))
//            {
//                return View("Index", _context.Teachers.ToList());
//            }

//            var results = _context.Teachers
//                .Where(t => t.Relations.Any(r => r.Courses.CourseName.Contains(searchTerm)))
//                .ToList();

//            return View("SearchResults", results);
//        }


//    }
//}
