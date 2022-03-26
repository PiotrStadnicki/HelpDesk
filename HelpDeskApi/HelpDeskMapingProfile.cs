using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelpDeskApi.Entities;
using HelpDeskApi.Models;


namespace HelpDeskApi
{
    public class HelpDeskMapingProfile :Profile
    {
        public HelpDeskMapingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ProblemPlace, ProblemPlaceDto>();
            

            CreateMap<CreateClientDto, Client>();
            CreateMap<CreateProblemPlaceDto, ProblemPlace>();
            



        }


    }
}
