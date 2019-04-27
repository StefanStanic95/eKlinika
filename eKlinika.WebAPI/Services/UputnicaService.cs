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
    public class UputnicaService : IUputnicaService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public UputnicaService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Uputnica> Get(UputnicaSearchRequest request)
        {
            var query = _context.Uputnica.AsQueryable();

            if (request?.DatumOd != null && request?.DatumDo != null)
            {
                query = query.Where(x => x.DatumUputnice.Date >= request.DatumOd.Value.Date && x.DatumUputnice.Date <= request.DatumDo.Value.Date);
            }

            query = IncludeDetails(query);

            var list = query
                .ToList();

            return _mapper.Map<List<Model.Uputnica>>(list);
        }

        private static IQueryable<Uputnica> IncludeDetails(IQueryable<Uputnica> query)
        {
            return query
                .Include(x => x.LaboratorijDoktor.Osoblje.Korisnik)
                .Include(x => x.UputioDoktor.Osoblje.Korisnik)
                .Include(x => x.Pacijent.Korisnik)
                .Include(x => x.VrstaPretrage);
        }

        public Model.Uputnica GetById(int id)
        {
            var entity = _context.Uputnica.Where(x => x.Id == id);
            entity = IncludeDetails(entity);

            return _mapper.Map<Model.Uputnica>(entity.FirstOrDefault());
        }

        public Model.Uputnica Insert(Model.Uputnica request)
        {
            var entity = _mapper.Map<Database.Uputnica>(request);

            _context.Uputnica.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Uputnica>(entity);
        }

        public Model.Uputnica Update(int id, Model.Uputnica request)
        {
            var result = _context.Uputnica.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Uputnica.Attach(entity);
            _context.Uputnica.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Uputnica>(entity);
        }
        
    }
}
