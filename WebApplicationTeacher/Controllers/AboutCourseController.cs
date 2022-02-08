using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Data;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Controllers
{
    public class AboutCourseController : Controller
    {
        private readonly ICourseRepository _repo;
        public AboutCourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var course = _repo.Courses.ToList();
            return View(course);
        }

        public IActionResult Course(long Id)
        {
            
            var course = _repo.Courses.Single(p => p.Id == Id);
            return View(course);
        }

        public IActionResult CourseBuying(long Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public IActionResult CourseBuying(BuyerModel model)
        {
            var buyer = new CourseBuyingModel()
            {
                Course = model.Course,
                PhoneNumber = model.PhoneNumber,
                SocialNetwork = model.SocialNetwork
            };
            var user = User;
            DataHelper.SaveBuyerChanges(buyer, user);
            var course = _repo.Courses.ToList();
            return View("Index", course);
        }
    }
}
