using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpDeskApi.Entities;
using HelpDeskApi.Models;
using HelpDeskApi.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HelpDeskApi.Controllers
{
    [Route("api/Client")]
    


    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;


        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;


        }

        


        [HttpPut("{id}")]

        public ActionResult Update([FromBody] UpdateClientDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _clientService.Update(id, dto);
            
            return Ok();
        }



        [HttpPost]
        
        public ActionResult CreateClient([FromBody] CreateClientDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var id= _clientService.Create(dto);
            return Created($"/api/Client/{id}", null);

        }

        [HttpGet]

        public ActionResult<IEnumerable<ClientDto>> GetAll([FromQuery] ClientQuery query)
        {
            var clientsDtos = _clientService.GetAll(query);


            return Ok(clientsDtos);

        }
        [HttpGet("{id}")]
        public ActionResult<ClientDto> Get([FromRoute] int id)
        {


            var client = _clientService.GetById(id);
            return Ok(client);

            
        
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
             _clientService.Delete(id);
            return NoContent();
            
        }


    }
}
