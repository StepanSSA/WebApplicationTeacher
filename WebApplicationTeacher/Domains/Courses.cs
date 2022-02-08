using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    public class Courses
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Длительность курса")]
        public string Size { get; set; }
        [Display(Name = "Видео")]
        public string Videos { get; set; }
    }
}
