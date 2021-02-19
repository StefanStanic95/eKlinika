using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator,Apotekar,Pacijent")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ApotekaRacunController : ControllerBase
    {
        private readonly IApotekaRacunService _service;
        public ApotekaRacunController(IApotekaRacunService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.ApotekaRacun> Get([FromQuery]ApotekaRacunSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.ApotekaRacun Insert(ApotekaRacunInsertRequest request)
        {
            return _service.Insert(request);
        }
        [AllowAnonymous]
        [HttpGet("{id}/UplataIzvrsena/{PaymentMethodId}")]
        public JsonResult UplataIzvrsena(int id, string PaymentMethodId)
        {
            return new JsonResult(_service.UplataIzvrsena(id, PaymentMethodId));
        }

        [HttpPut("{id}")]
        public Model.ApotekaRacun Update(int id, [FromBody]ApotekaRacunInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.ApotekaRacun GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}