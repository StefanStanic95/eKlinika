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
    public class UplateController : ControllerBase
    {
        private readonly IUplateService _service;
        public UplateController(IUplateService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,MedicinskaSestra")]
        [HttpGet]
        public List<Model.Uplata> Get([FromQuery]UplateSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator,MedicinskaSestra")]
        [HttpPost]
        public Model.Uplata Insert(Uplata request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,MedicinskaSestra")]
        [HttpPut("{id}")]
        public Model.Uplata Update(int id, [FromBody]Uplata request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Administrator,MedicinskaSestra")]
        [HttpGet("{id}")]
        public Model.Uplata GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}