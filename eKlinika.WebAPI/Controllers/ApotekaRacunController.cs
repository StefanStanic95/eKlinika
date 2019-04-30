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
    public class ApotekaRacunController : ControllerBase
    {
        private readonly IApotekaRacunService _service;
        public ApotekaRacunController(IApotekaRacunService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet]
        public List<Model.ApotekaRacun> Get([FromQuery]ApotekaRacunSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPost]
        public Model.ApotekaRacun Insert(ApotekaRacunInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPut("{id}")]
        public Model.ApotekaRacun Update(int id, [FromBody]ApotekaRacunInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet("{id}")]
        public Model.ApotekaRacun GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}