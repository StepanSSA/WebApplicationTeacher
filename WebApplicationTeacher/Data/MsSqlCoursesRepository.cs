using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class MsSqlCoursesRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public MsSqlCoursesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Courses> Courses => _context.Courses;

        public IQueryable<CourseBuyingModel> CourseBuying => _context.CourseBuying;
    }
}
