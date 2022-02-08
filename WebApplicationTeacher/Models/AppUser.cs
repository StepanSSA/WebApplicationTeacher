using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }
    }
}
