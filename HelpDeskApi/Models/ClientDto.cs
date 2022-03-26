using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelpDeskApi.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public virtual List<ProblemPlaceDto> ProblemsPlaces { get; set; }

        
    }
}
