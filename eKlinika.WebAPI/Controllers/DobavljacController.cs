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
    public class DobavljacController : BaseController<Model.Dobavljac, object>
    {
        public DobavljacController(IService<Dobavljac, object> service) : base(service)
        {
        }
    }
}