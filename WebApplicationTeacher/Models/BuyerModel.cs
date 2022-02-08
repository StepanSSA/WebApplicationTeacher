using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Models
{
    public class BuyerModel
    {
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "WhatsApp/Telegram/В Контакте")]
        public string SocialNetwork { get; set; }
        [Required]
        [Display(Name = "Номер курса")]
        public string Course { get; set; }
    }
}
