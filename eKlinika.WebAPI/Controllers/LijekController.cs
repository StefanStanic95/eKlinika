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
    public class LijekController : ControllerBase
    {
            private readonly ILijekService _service;
            public LijekController(ILijekService service)
            {
                _service = service;
            }

            [Authorize(Roles = "Administrator,Apotekar")]
            [HttpGet]
            public List<Model.Lijek> Get([FromQuery]LijekSearchRequest request)
            {
                return _service.Get(request);
            }

            [Authorize(Roles = "Administrator,Apotekar")]
            [HttpGet("{id}")]
            public Model.Lijek GetById(int id)
            {
                return _service.GetById(id);
            }

            [Authorize(Roles = "Administrator,Apotekar")]
            [HttpPost]
            public Model.Lijek Insert(LijekInsertRequest request)
            {
                return _service.Insert(request);
            }

            [Authorize(Roles = "Administrator,Apotekar")]
            [HttpPut("{id}")]
            public Model.Lijek Update(int id, [FromBody]LijekInsertRequest request)
            {
                return _service.Update(id, request);
            }
    }
}