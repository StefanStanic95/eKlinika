using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Model;
using eKlinika.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.WebAPI.Controllers
{
    public class ProizvodjacController : BaseController<Model.Proizvodjac, object>
    {
        public ProizvodjacController(IService<Proizvodjac, object> service) : base(service)
        {
        }
    }
}