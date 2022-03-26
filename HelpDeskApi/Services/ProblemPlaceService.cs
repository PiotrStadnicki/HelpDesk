
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskApi.Models;
using HelpDeskApi.Entities;
using HelpDeskApi;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HelpDeskApi.Exceptions;
 


namespace HelpDeskApi.Services
{
    public interface IProblemPlaceService
    {
        int Create(int clientId, CreateProblemPlaceDto dto);
        ProblemPlaceDto GetByID(int clientId, int dishproblemPlaceIdId);
        List<ProblemPlaceDto> GetAll(int clientID);

        void RemoveALL(int  clientId);


    }

    public class ProblemPlaceService : IProblemPlaceService
    {
        private readonly HelpDeskDbContext _context;
        private readonly IMapper _mapper;
        public ProblemPlaceService(HelpDeskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public int Create(int clientId, CreateProblemPlaceDto dto)
        {
            var client = GetClientById(clientId);

            var problemPlaceEntity = _mapper.Map<ProblemPlace>(dto);
            problemPlaceEntity.ClientID = clientId;


            _context.ProblemsPlace.Add(problemPlaceEntity);

            _context.SaveChanges();
            return problemPlaceEntity.Id;


        }
        public ProblemPlaceDto GetByID(int clientId, int problemPlaceId)
        {
            var client = GetClientById(clientId);

            var problemPlace = _context.ProblemsPlace.FirstOrDefault(p => p.Id == problemPlaceId);
            if (problemPlace is null || problemPlace.ClientID != clientId)
            {
                throw new NotFoundException("Miejsce nie obsługiwane");
            }
            var problemPlaceDto = _mapper.Map<ProblemPlaceDto>(problemPlace);
            return problemPlaceDto;
        }
        public List<ProblemPlaceDto> GetAll(int clientId)
        {
            var client = GetClientById(clientId);
            var problemPlacesDtos = _mapper.Map<List<ProblemPlaceDto>>(client.ProblemPlaces);
            return problemPlacesDtos;

        }

        public void RemoveALL(int clientId)
        {
            var client = GetClientById(clientId);
            _context.RemoveRange(client.ProblemPlaces);
            _context.SaveChanges();
        }





        private Client GetClientById(int clientId)
        {
            var client = _context
               .Clients
               .Include(c => c.ProblemPlaces)
               .FirstOrDefault(c => c.Id == clientId);

            if (client is null)
                throw new NotFoundException("Client not found");
            

            return client;

        }


    }
}
