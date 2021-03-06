﻿using System;
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
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("me")]
        public Model.Korisnici GetMe()
        {
            return _service.GetMe();
        }

        [Authorize(Roles = "Administrator,Referent")]
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "Administrator,Referent")]
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, [FromBody]KorisniciUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Pacijent")]
        [HttpPut("UpdatePacijent/{id}")]
        public Model.Korisnici UpdatePacijent(int id, [FromBody]PacijentUpdateRequest request)
        {
            return _service.UpdatePacijent(id, request);
        }

        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}