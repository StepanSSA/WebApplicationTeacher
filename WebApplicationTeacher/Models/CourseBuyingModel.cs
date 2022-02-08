using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Models
{
    public class CourseBuyingModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "WhatsApp/Telegram/В Контакте")]
        public string SocialNetwork { get; set; }
        [Required]
        [Display(Name = "Номер курса")]
        public string Course { get; set; }
        [Required]
        public string Account { get; set; }
    }
}
