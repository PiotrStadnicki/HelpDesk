
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskApi.Models;
using HelpDeskApi.Entities;
using HelpDeskApi.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace HelpDeskApi.Services
{

    public interface IClientServices
    {
         ClientDto GetById(int id);
         PageResult<ClientDto> GetAll( ClientQuery  query);
         int Create(CreateClientDto dto);

         void Delete(int id);
         void Update(int id, UpdateClientDto dto);

    }

    public class ClientServices : IClientServices
    {
        private readonly HelpDeskDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientServices> _logger;

        public ClientServices (HelpDeskDbContext dbContext , IMapper mapper, ILogger<ClientServices> logger  )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Update(int id, UpdateClientDto dto)
        {
            
            var client = _dbContext
              .Clients
             .FirstOrDefault(c => c.Id == id);

            if (client is null)
                throw new NotFoundException("Brak klienta");
            

            client.Name = dto.Name;
            client.Description = dto.Description;
            client.ServiceMenager = dto.ServiceMenager;

            _dbContext.SaveChanges();


            

        }
        public void Delete(int id)
        {
            _logger.LogWarning($"Client witch id:{id} Delete action invoked");
            var client = _dbContext.Clients
             .FirstOrDefault(c => c.Id == id);

            if (client is null) throw new NotFoundException("Brak klienta");

            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            

        }


        public ClientDto GetById (int id)
        {

            var client = _dbContext.Clients

            .Include(c => c.ProblemPlaces)
            .FirstOrDefault(c => c.Id == id);

            if (client is null)
                throw new NotFoundException("Brak klienta"); 
            
            var result = _mapper.Map<ClientDto>(client);
            return result;
        }
        public PageResult<ClientDto> GetAll(ClientQuery query)
        {

            var baseQuery = _dbContext
                .Clients
                .Include(c => c.ProblemPlaces)
                .Where(c => query.SearchPhrase == null || (c.Name.ToLower().Contains(query.SearchPhrase.ToLower()) || c.Description.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnSelector = new Dictionary<string, Expression<Func<Client, Object>>>
                    {
                           {nameof(Client.Name), c=> c.Name },
                           {nameof(Client.ServiceMenager), c=> c.ServiceMenager },
                           {nameof(Client.Contrac), c=> c.Contrac }
                     };

                var selectedColumn = columnSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                     baseQuery.OrderBy(c => c.Name)
                     : baseQuery.OrderByDescending(c => c.ServiceMenager);
            
            }

            var clients = baseQuery
                 .Skip(query.PageSize* (query.PageNumber -1))

                .Take(query.PageSize)
                .ToList();


            var totalItemsCount = baseQuery.Count();

            var clienDtos = _mapper.Map<List<ClientDto>>(clients);
            var result = new PageResult<ClientDto>(clienDtos , totalItemsCount, query.PageSize,query.PageNumber);

            return result;
        }

        public int Create(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return client.Id;

        }


    }
}
