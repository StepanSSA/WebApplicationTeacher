using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class MsSqlCRUDRepository : ICRUDRepository
    {
        private readonly ApplicationDbContext _context;

        public MsSqlCRUDRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Courses> Courses => _context.Courses;

        public IQueryable<CourseBuyingModel> CourseBuying => _context.CourseBuying;

        public void Delete(CourseBuyingModel buyer)
        {
            _context.CourseBuying.Remove(buyer);
            _context.SaveChanges();
        }

        public void Delete(Courses courses)
        {
            _context.Courses.Remove(courses);
            _context.SaveChanges();
        }

        public void Update(Courses courses)
        {
            _context.Update(courses);
            _context.SaveChanges();
        }
    }
}
