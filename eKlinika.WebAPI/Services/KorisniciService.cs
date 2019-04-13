using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public KorisniciService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Korisnici> Get(KorisniciSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.ImePrezime));
            }

            if (request?.IsUlogeLoadingEnabled == true)
            {
                
            }


            var list = query.ToList();

            var response = _mapper.Map<List<Model.Korisnici>>(list);

            return response;
        }

        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);

            return _mapper.Map<Model.Korisnici>(entity);
        }

        //public Model.Korisnici Insert(KorisniciInsertRequest request)
        //{
        //    var entity = _mapper.Map<Database.Korisnici>(request);

        //    if (request.Password != request.PasswordPotvrda)
        //    {
        //        throw new Exception("Passwordi se ne slažu");
        //    }

        //    entity.LozinkaHash = "test";
        //    entity.LozinkaSalt = "test";

        //    _context.Korisnici.Add(entity);
        //    _context.SaveChanges();

        //    return _mapper.Map<Model.Korisnici>(entity);
        //}

        //public Model.Korisnici Update(int id, KorisniciInsertRequest request)
        //{
        //    var entity = _context.Korisnici.Find(id);
        //    _context.Korisnici.Attach(entity);
        //    _context.Korisnici.Update(entity);

        //    _mapper.Map(request, entity);

        //    _context.SaveChanges();

        //    return _mapper.Map<Model.Korisnici>(entity);
        //}
    }
}
