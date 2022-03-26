using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Models
{
    public class UpdateClientDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceMenager { get; set; }
        public bool Contrac { get; set; }

    }
}
