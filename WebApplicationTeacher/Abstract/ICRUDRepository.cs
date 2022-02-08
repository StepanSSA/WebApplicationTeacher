using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Abstract
{
    public interface ICRUDRepository : ICourseRepository
    {
        public void Delete(CourseBuyingModel buyer);
        public void Delete(Courses courses);
        public void Update(Courses courses);
    }
}
