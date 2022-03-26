using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities

{
    public class ProblemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProblemPlaceId { get; set; }
        public virtual ProblemPlace ProblemPlace { get; set; }
        
        public virtual List<Problem> Problem { get; set; }


    }
}
