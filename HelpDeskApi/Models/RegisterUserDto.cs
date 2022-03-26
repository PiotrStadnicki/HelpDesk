using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Models
{
    public class RegisterUserDto
    {
        
        public string Email { get; set; }
        
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
       


        public DateTime? WorkStart { get; set; }

        public int RoleId { get; set; } = 1;

        
    }
}
