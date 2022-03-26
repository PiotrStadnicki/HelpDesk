using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HelpDeskApi.Entities;
using HelpDeskApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace HelpDeskApi.Models
{
    public class CreateClientDto
    {
       
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string ServiceMenager { get; set; }
        public int Level { get; set; } = 4;
        public bool Contrac { get; set; }


    }
}
