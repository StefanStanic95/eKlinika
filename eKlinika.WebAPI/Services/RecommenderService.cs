using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eKlinika.WebAPI.Services
{
    public class RecommenderService : IRecommenderService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Doktor> Get(int PregledId)
        {
            var query = _context.Doktor.AsQueryable();

            List<string> specijalizacijeUstanovljenihDijagnoza = _context.UstanovljenaDijagnoza
                .Where(x => x.PregledId == PregledId)
                .Select(x=>x.Dijagnoza.DoktorSpecijalizacija)
                .ToList();

            query = query.Where(x => specijalizacijeUstanovljenihDijagnoza.Contains(x.Specijalizacija));

            query = query.Include(x => x.Osoblje.Korisnik);

            var list = query.ToList();

            return _mapper.Map<List<Model.Doktor>>(list);
        }
        
    }
}
