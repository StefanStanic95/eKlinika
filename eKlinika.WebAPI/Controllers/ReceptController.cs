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
    public class ReceptController : ControllerBase
    {
        private readonly IReceptService _service;
        public ReceptController(IReceptService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet]
        public List<Model.Recept> Get([FromQuery]ReceptSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPost]
        public Model.Recept Insert(ReceptInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpPut("{id}")]
        public Model.Recept Update(int id, [FromBody]ReceptInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,Apotekar")]
        [HttpGet("{id}")]
        public Model.Recept GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}