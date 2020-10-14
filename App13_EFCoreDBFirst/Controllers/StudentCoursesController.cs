using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App13_EFCoreDBFirst.Models;
using System.Data.SqlTypes;

namespace App13_EFCoreDBFirst.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly BITM9Context _context;

        public StudentCoursesController(BITM9Context context)
        {
            _context = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index()
        {
            var bITM9Context = _context.StudentCourse.Include(s => s.Course).Include(s => s.Student);
            return View(await bITM9Context.ToListAsync());
        }

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["studentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,studentId,ResultGradePoint,ResultLetterGrade")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                int stdid = studentCourse.studentId;
                int courseid = studentCourse.CourseId;

                var result = _context.StudentCourse.FirstOrDefault(x => x.studentId == stdid && x.CourseId == courseid);
                if (result == null)
                {
                    _context.Add(studentCourse);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.msg = " AlreadyFilled Exception Exists";
                }
               
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentCourse.CourseId);
            ViewData["studentId"] = new SelectList(_context.Student, "Id", "Name", studentCourse.studentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentCourse.CourseId);
            ViewData["studentId"] = new SelectList(_context.Student, "Id", "Name", studentCourse.studentId);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,studentId,ResultGradePoint,ResultLetterGrade")] StudentCourse studentCourse)
        {
            if (id != studentCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentCourse.CourseId);
            ViewData["studentId"] = new SelectList(_context.Student, "Id", "Name", studentCourse.studentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourse.FindAsync(id);
            _context.StudentCourse.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourse.Any(e => e.Id == id);
        }
    }
}
