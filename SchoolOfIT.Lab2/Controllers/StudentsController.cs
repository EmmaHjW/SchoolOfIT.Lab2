using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolOfIT.Lab2.Data;
using SchoolOfIT.Lab2.Models;

namespace SchoolOfIT.Lab2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolOfITContext _context;

        public StudentsController(SchoolOfITContext context)
        {
            _context = context;
        }

        // GET: Students
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Students != null ? 
        //                  View(await _context.Students.ToListAsync()) :
        //                  Problem("Entity set 'SchoolOfITContext.Students'  is null.");
        //}

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FullName,Email,Address,City,DateOfBirth")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FullName,Email,Address,City,DateOfBirth")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'SchoolOfITContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Search(string searchString = "")
        {
            List<RelationTable> relationTables = new List<RelationTable>();
            relationTables = await _context.Relations.ToListAsync();
            var data = await (from r in _context.Relations
                              join s in _context.Students on r.FK_StudentId equals s.StudentId
                              join t in _context.Teachers on r.FK_TeacherId equals t.TeacherId
                              join c in _context.Courses on r.FK_CourseId equals c.CourseId
                              where c.CourseName.Contains(searchString)
                              select new
                              {
                                  StudentId = s.StudentId,
                                  TeacherId = t.TeacherId,
                                  StudentName = s.FullName,
                                  TeacherName = t.FullName,
                                  CourseName = c.CourseName
                              }).ToListAsync();
            List<SearchViewModel> searchViewModel = new List<SearchViewModel>();
            foreach (var item in data)
            {
                var test = new SearchViewModel
                {
                    TeacherId = item.TeacherId,
                    StudentId = item.StudentId,
                    StudentName = item.StudentName,
                    TeacherName = item.TeacherName,
                    CourseName = item.CourseName
                };
                searchViewModel.Add(test);
            }

            return View(searchViewModel);
        }
    }
}
