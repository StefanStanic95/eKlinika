using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eKlinika.WebAPI.Security;

namespace eKlinika.WebAPI.Services
{
    public class PregledService : IPregledService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public PregledService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Pregled> Get(PregledSearchRequest request)
        {
            var query = _context.Pregled.AsQueryable();

            if (request?.DatumPregleda != null)
            {
                query = query.Where(x => x.DatumPregleda.Date == request.DatumPregleda.Value.Date);
            }

            query = IncludeUserDetails(query);

            var list = query
                .ToList();

            return _mapper.Map<List<Model.Pregled>>(list);
        }

        private static IQueryable<Pregled> IncludeUserDetails(IQueryable<Pregled> query)
        {
            return query
                .Include(x => x.Doktor.Osoblje.Korisnik)
                .Include(x => x.Pacijent.Korisnik)
                .Include(x => x.MedicinskaSestra.Osoblje.Korisnik);
        }

        public Model.Pregled GetById(int id)
        {
            var entity = _context.Pregled.Where(x => x.Id == id);
            entity = IncludeUserDetails(entity);

            return _mapper.Map<Model.Pregled>(entity.FirstOrDefault());
        }

        public Model.Pregled Insert(PregledInsertRequest request)
        {
            var entity = _mapper.Map<Database.Pregled>(request);

            _context.Pregled.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Pregled>(entity);
        }

        public Model.Pregled Update(int id, PregledInsertRequest request)
        {
            var result = _context.Pregled.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Pregled.Attach(entity);
            _context.Pregled.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Pregled>(entity);
        }
        
    }
}
