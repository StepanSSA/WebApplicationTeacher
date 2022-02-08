using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Abstract
{
    public interface ICourseRepository
    {
        public IQueryable<Courses> Courses { get;}
        public IQueryable<CourseBuyingModel> CourseBuying { get; }
    }
}
