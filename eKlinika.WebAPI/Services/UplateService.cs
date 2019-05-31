using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using eKlinika.WebAPI.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{

    public class UplateService : IUplateService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public UplateService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Uplata> Get(UplateSearchRequest request)
        {
            var query = _context.Uplata.AsQueryable();

            if (request?.BrojUplatnice != null)
            {
                query = query.Where(x => x.BrojUplatnice == request.BrojUplatnice);
            }

            foreach (var uloga in BasicAuthenticationHandler.korisnik.KorisniciUloge)
            {
                if (uloga.Uloga.Naziv == "Pacijent")
                {
                    query = query.Where(x => x.PacijentId == BasicAuthenticationHandler.korisnik.Id);
                    break;
                }
            }

            query = IncludeDetails(query);

            var list = query
                .ToList();

            return _mapper.Map<List<Model.Uplata>>(list);
        }

        private static IQueryable<Uplata> IncludeDetails(IQueryable<Uplata> query)
        {
            return query
                .Include(x => x.Pacijent.Korisnik)
                .Include(x => x.Pregled);

        }

        public Model.Uplata GetById(int id)
        {
            var entity = _context.Uplata.Where(x => x.Id == id);
            entity = IncludeDetails(entity);

            return _mapper.Map<Model.Uplata>(entity.FirstOrDefault());
        }

        public Model.Uplata Insert(Model.Uplata request)
        {
            var entity = _mapper.Map<Database.Uplata>(request);

            _context.Uplata.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Uplata>(entity);
        }

        public Model.Uplata Update(int id, Model.Uplata request)
        {
            var result = _context.Uplata.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Uplata.Attach(entity);
            _context.Uplata.Update(entity);

            _mapper.Map(request, entity);


            _context.SaveChanges();

            return _mapper.Map<Model.Uplata>(entity);
        }

    }
}
