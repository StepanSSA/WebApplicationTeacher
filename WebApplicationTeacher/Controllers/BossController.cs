using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Data;
using WebApplicationTeacher.Domains;

namespace WebApplicationTeacher.Controllers
{
    public class BossController : Controller
    {
        private readonly ICourseRepository _repo;
        private readonly ICRUDRepository _crudRepo;
        public BossController(ICourseRepository repo, ICRUDRepository crudRepo)
        {
            _repo = repo;
            _crudRepo = crudRepo;
        }

        public IActionResult ListCourse()
        {
            var courses = _repo.Courses.ToList();
            if(courses == null)
                return RedirectToAction("Index", "Home");
            return View(courses);
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Courses course)
        {
            DataHelper.SaveChanges(course);
            var courses = _repo.Courses.ToList();
            return View("ListCourse", courses);
        }

        public IActionResult Edit(long id)
        {
            var course = _repo.Courses.Single(c => c.Id == id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Courses course)
        {
            _crudRepo.Update(course);
            var courses = _repo.Courses.ToList();
            return View("ListCourse", courses);
        }

        public IActionResult Delete(long id)
        {
            var course = _repo.Courses.Single(c => c.Id == id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(Courses course)
        {
            _crudRepo.Delete(course);
            var courses = _repo.Courses.ToList();
            return View("ListCourse", courses);
        }

        public IActionResult ListBuyers()
        {
            var buyer = _repo.CourseBuying.ToList();
            if (buyer == null)
                return RedirectToAction("Index", "Home");
            return View(buyer);
        }

        public IActionResult Confirm(long id)
        {
            var buyer = _repo.CourseBuying.FirstOrDefault(c => c.Id == id);
            DataHelper.Confirm(buyer);
            _crudRepo.Delete(buyer);
            return RedirectToAction("Index", "Home");
        }

    }
}
