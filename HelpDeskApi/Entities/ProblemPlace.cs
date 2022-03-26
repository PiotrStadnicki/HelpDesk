using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities
{
    public class ProblemPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ProblemCategory> ProblemsCategory { get; set; }
    }
}
