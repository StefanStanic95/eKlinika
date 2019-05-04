using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RacunStavkaController : ControllerBase
    {
        private readonly IRacunStavkaService _service;
        public RacunStavkaController(IRacunStavkaService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet]
        public List<Model.RacunStavka> Get([FromQuery]RacunStavkaSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPost]
        public Model.RacunStavka Insert(RacunStavkaInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPut("{id}")]
        public Model.RacunStavka Update(int id, [FromBody]RacunStavkaInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet("{id}")]
        public Model.RacunStavka GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}