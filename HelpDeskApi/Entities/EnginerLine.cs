using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities
{
    public class EnginerLine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public virtual Location Location { get; set; }
    }
}
