using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities

{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UnderService { get; set; }
        
        public string Description { get; set; }
        public int ProblemCategoryId { get; set; }
        

        public virtual ProblemCategory ProblemCategory { get; set; }
        public List <ProblemSolution>  ProblemSolution { get; set; }


    }
}
