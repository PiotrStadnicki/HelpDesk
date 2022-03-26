using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskApi.Models
{
    public class CreateProblemPlaceDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ClientID { get; set; }
    }
}
