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
    public class ApotekaRacunService : IApotekaRacunService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public ApotekaRacunService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.ApotekaRacun> Get(ApotekaRacunSearchRequest request)
        {
            var query = _context.ApotekaRacun.AsQueryable();

            if (request?.DatumIzdavanja != null)
            {
                query = query.Where(x => x.DatumIzdavanja.Date == request.DatumIzdavanja.Value.Date);
            }

            query = query.Include(x => x.Pacijent.Korisnik).Include(x => x.Apotekar.Osoblje.Korisnik);

            var list = query.ToList();

            return _mapper.Map<List<Model.ApotekaRacun>>(list);
        }


        public Model.ApotekaRacun GetById(int id)
        {
            var entity = _context.ApotekaRacun
                .Where(x => x.Id == id)
                .Include(x => x.Pacijent.Korisnik)
                .Include(x => x.Apotekar.Osoblje.Korisnik);


            return _mapper.Map<Model.ApotekaRacun>(entity.FirstOrDefault());
        }

        public Model.ApotekaRacun Insert(ApotekaRacunInsertRequest request)
        {
            var entity = _mapper.Map<Database.ApotekaRacun>(request);

            _context.ApotekaRacun.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.ApotekaRacun>(entity);
        }

        public Model.ApotekaRacun Update(int id, ApotekaRacunInsertRequest request)
        {
            var result = _context.ApotekaRacun.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.ApotekaRacun.Attach(entity);
            _context.ApotekaRacun.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.ApotekaRacun>(entity);
        }

    }
}
