using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;

using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    //controller used for remote validation
    //Doraditi i popraviti
    public class ApotekaValidationController : Controller
    {
        private ApplicationDbContext _context;

        public ApotekaValidationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult KolicineValidacija(object lista)
        {
            var list = lista as List<int>;
            //testing
            return Json("no");
        }
    }
}
