using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities
{
    public class ProblemSolution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Step1 { get; set; }
        public string Step2 { get; set; }
        public string Step3 { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public int ProblemId { get; set; }

        
        public virtual Problem Problem { get; set; }



    }
}
