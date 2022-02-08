using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class SimpleCourseRepository : ICourseRepository
    {
        public IQueryable<Courses> Courses =>
            new List<Courses>()
            {
                new Courses()
                {
                    Name = "Beginner",
                    Description = "На этом курсе вы познакомитесь с основами Английского языка",
                    Price = 5000,
                    Size = "10 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=fUUiTusi0-8"
                },
                new Courses()
                {
                    Name = "Elementary",
                    Description = "На этом курсе вы продолжите изучать основы Английского языка",
                    Price = 7000,
                    Size = "12 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=-KHc8kJpZXU"
                },
                new Courses()
                {
                    Name = "Intermediate",
                    Description = "На этом курсе вы поднимите свои знания языка ддо уровня Intermediate",
                    Price = 9000,
                    Size = "10 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=Hp9wUEDasY4&list=PLD6SPjEPomaustGSgYNsn3V62BTQeH85X"
                },
                new Courses()
                {
                    Name = "Upper Intermediate",
                    Description = "На этом курсе вы поднимите свои знания языка ддо уровня Upper Intermediate",
                    Price = 11000,
                    Size = "10 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=Hp9wUEDasY4&list=PLD6SPjEPomaustGSgYNsn3V62BTQeH85X"
                },
                new Courses()
                {
                    Name = "Advanced",
                    Description = "На этом курсе вы поднимите свои знания языка ддо уровня Advanced",
                    Price = 13000,
                    Size = "10 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=Hp9wUEDasY4&list=PLD6SPjEPomaustGSgYNsn3V62BTQeH85X"
                },
                new Courses()
                {
                    Name = "Proficiency",
                    Description = "На этом курсе вы поднимите свои знания языка ддо уровня Proficiency",
                    Price = 5000,
                    Size = "10 видео уроков",
                    Videos = @"https://www.youtube.com/watch?v=Hp9wUEDasY4&list=PLD6SPjEPomaustGSgYNsn3V62BTQeH85X"
                },
            }.AsQueryable();

        public IQueryable<CourseBuyingModel> CourseBuying => throw new NotImplementedException();
    }
}
