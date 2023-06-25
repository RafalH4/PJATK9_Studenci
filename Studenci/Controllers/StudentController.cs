using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studenci.Models;

namespace Studenci.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _db;
        public StudentController(StudentContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var students = _db.Students.ToList();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = _db.Students.Find(id);

            if (student != null)
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var student = _db.Students.Find(id);

            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search(string indexNumber)
        {
            if (!string.IsNullOrEmpty(indexNumber))
            {
                var filteredStudents = _db.Students.Where(s => s.IndexNumber == indexNumber).ToList();
                return View("Index", filteredStudents);
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }

}
