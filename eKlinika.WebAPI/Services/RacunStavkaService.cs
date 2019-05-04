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
    public class RacunStavkaService : IRacunStavkaService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public RacunStavkaService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.RacunStavka> Get(RacunStavkaSearchRequest request)
        {
            var query = _context.RacunStavka.AsQueryable();

            if (request?.ApotekaRacunId != 0)
            {
                query = query.Where(x => x.ApotekaRacunId == request.ApotekaRacunId);
            }

            query = query.Include(x => x.Lijek);

            var list = query.ToList();
            
            return _mapper.Map<List<Model.RacunStavka>>(list);
        }


        public Model.RacunStavka GetById(int id)
        {
            var entity = _context.RacunStavka
                .Where(x => x.Id == id)
                .Include(x => x.Lijek);

            return _mapper.Map<Model.RacunStavka>(entity.FirstOrDefault());
        }

        public Model.RacunStavka Insert(RacunStavkaInsertRequest request)
        {
            var entity = _mapper.Map<Database.RacunStavka>(request);

            _context.RacunStavka.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.RacunStavka>(entity);
        }

        public Model.RacunStavka Update(int id, RacunStavkaInsertRequest request)
        {
            var result = _context.RacunStavka.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.RacunStavka.Attach(entity);
            _context.RacunStavka.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.RacunStavka>(entity);
        }

    }
}
