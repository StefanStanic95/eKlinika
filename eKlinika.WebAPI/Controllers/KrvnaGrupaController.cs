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
    public class KrvnaGrupaController : BaseController<Model.KrvnaGrupa, object>
    {
        public KrvnaGrupaController(IService<KrvnaGrupa, object> service) : base(service)
        {
        }
    }
}