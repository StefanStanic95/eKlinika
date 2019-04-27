using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Model;
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
    public class PregledController : ControllerBase
    {
        private readonly IPregledService _service;
        public PregledController(IPregledService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Doktor,MedicinskaSestra")]
        [HttpGet]
        public List<Model.Pregled> Get([FromQuery]PregledSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Doktor")]
        [HttpPost]
        public Model.Pregled Insert(Pregled request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Doktor")]
        [HttpPut("{id}")]
        public Model.Pregled Update(int id, [FromBody]Pregled request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Doktor,MedicinskaSestra")]
        [HttpGet("{id}")]
        public Model.Pregled GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}