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
    [Route("api/Client/{ClientId}/ProblemPlace")]
    [ApiController]
    [Authorize]
    public class ProblemPlaceController : ControllerBase
    {

        private readonly IProblemPlaceService _problemPlaceService;

        public ProblemPlaceController(IProblemPlaceService problemPlaceService)

        {
            _problemPlaceService = problemPlaceService;
        }

        [HttpDelete]

        public ActionResult Delete([FromRoute] int clientId)
        {
            _problemPlaceService.RemoveALL(clientId);
            return NoContent();


        }

        [HttpPost]
        [Authorize(Roles = "Admin,HelpDeskMenager")]
        
        public ActionResult Post([FromRoute] int clientId, [FromBody] CreateProblemPlaceDto dto)
        {
            var newProblemPlaceId = _problemPlaceService.Create(clientId, dto);


            return Created($"api/Client/{clientId} /ProblemPlace/ {newProblemPlaceId}", null);


        }
        [HttpGet ("{problemPlaceId}")]
        public ActionResult<ProblemPlaceDto> Get([FromRoute] int clientId, [FromRoute] int problemPlaceId)

        {
            ProblemPlaceDto problemPlace = _problemPlaceService.GetByID(clientId, problemPlaceId);
            return Ok(problemPlace);

        }
        [HttpGet]
        public ActionResult<List<ProblemPlaceDto>> Get([FromRoute] int clientId)

        {
            var resoult = _problemPlaceService.GetAll(clientId);
            return Ok(resoult);

        }
    }
}

