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
    public class NarudzbaController : ControllerBase
    {
        private readonly INarudzbaService _service;
        public NarudzbaController(INarudzbaService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet]
        public List<Model.Narudzba> Get([FromQuery]NarudzbaSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPost]
        public Model.Narudzba Insert(NarudzbaInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPut("{id}")]
        public Model.Narudzba Update(int id, [FromBody]NarudzbaInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet("{id}")]
        public Model.Narudzba GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}