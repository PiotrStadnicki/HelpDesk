using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Models
{
    public class CreateProblemDto
    {
        [Required]
        
        public string Name { get; set; }
        [Required]
        public bool UnderService { get; set; }
        [Required]
        public string Description { get; set; }
        public int ProblemCategoryId { get; set; }
    }
}
