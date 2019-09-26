using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Models;
using eKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eKlinika.Controllers
{
    public class DijagnozaController : Controller
    {
        ApplicationDbContext _db;
        public DijagnozaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int terminId)
        {
            UstanovljenaDijagnozaIndexVM model = new UstanovljenaDijagnozaIndexVM {
                PregledId=terminId,
                ustanovljeneDijagnoze= _db.UstanovljenaDijagnoza.Include(x=>x.Dijagnoza).Where(x => x.PregledId == terminId).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Dodaj(int Id)
        {
            UstanovljenaDijagnozaVM model = new UstanovljenaDijagnozaVM
            {
                PregledId=Id,
                DijagnozeList = _db.Dijagnoza.Select(x => new SelectListItem
                {
                    Text = x.Opis,
                    Value = x.Id.ToString()
                }).ToList()
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Dodaj(UstanovljenaDijagnozaVM model)
        {
            UstanovljenaDijagnoza ustanovljenaDijagnoza = new UstanovljenaDijagnoza
            {
                Detalji = model.Detalji,
                Napomena = model.Napomena,
                DijagnozaId = model.DijagnozaId,
                PregledId = model.PregledId
            };

            _db.Add(ustanovljenaDijagnoza);
            _db.SaveChanges();
            return RedirectToAction("EvidencijaPregleda","Pregledi", new {Id = model.PregledId });
        }

        public IActionResult DijagnozaDetails(int Id)
        {
            UstanovljenaDijagnoza model = _db.UstanovljenaDijagnoza.Include(x => x.Dijagnoza)
                                                                   .Include(x => x.Pregled)
                                                                   .Include(x => x.Pregled.Doktor)
                                                                   .Include(x => x.Pregled.Pacijent)
                                                                   .Where(x => x.Id == Id).FirstOrDefault();
            return PartialView(model);
        }

        public IActionResult DijagnozaDetailsIndex(int Id)
        {
            List<UstanovljenaDijagnoza> model = _db.UstanovljenaDijagnoza.Include(x => x.Dijagnoza)
                                                       .Include(x => x.Pregled)
                                                       .Include(x => x.Pregled.Doktor)
                                                       .Include(x => x.Pregled.Pacijent)
                                                       .Where(x => x.PregledId == Id).ToList();
            return PartialView(model);
        }
        public IActionResult Ukloni(int Id)
        {
            UstanovljenaDijagnoza model = _db.UstanovljenaDijagnoza.Where(x => x.Id == Id).FirstOrDefault();
            int pregledId = model.PregledId;
            _db.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("EvidencijaPregleda", "Pregledi", new { Id = pregledId });

        }
    }
}