using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber  { get; set; }
        
        public bool Contrac { get; set; }

        public string IdEnginerLine { get; set; }


        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }





    }
}
