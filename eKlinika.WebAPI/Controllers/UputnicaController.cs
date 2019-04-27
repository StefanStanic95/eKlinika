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
    public class UputnicaController : ControllerBase
    {
        private readonly IUputnicaService _service;
        public UputnicaController(IUputnicaService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Doktor,MedicinskaSestra")]
        [HttpGet]
        public List<Model.Uputnica> Get([FromQuery]UputnicaSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Doktor")]
        [HttpPost]
        public Model.Uputnica Insert(Uputnica request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Doktor")]
        [HttpPut("{id}")]
        public Model.Uputnica Update(int id, [FromBody]Uputnica request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Doktor,MedicinskaSestra")]
        [HttpGet("{id}")]
        public Model.Uputnica GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}