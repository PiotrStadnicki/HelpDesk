using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelpDeskApi.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceMenager { get; set; }
        public bool Contrac { get; set; }
        public int Level { get; set; }

        public virtual List<ProblemPlace> ProblemPlaces { get; set; }
        public virtual List<Location> Locations { get; set; }

    }
}
