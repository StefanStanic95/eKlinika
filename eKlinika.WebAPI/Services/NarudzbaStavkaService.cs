
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
    public class NarudzbaStavkaService : INarudzbaStavkaService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public NarudzbaStavkaService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.NarudzbaStavka> Get(NarudzbaStavkaSearchRequest request)
        {
            var query = _context.NarudzbaStavka.AsQueryable();

            if (request?.NarudzbaId != 0)
            {
                query = query.Where(x => x.NarudzbaId == request.NarudzbaId);
            }

            query = query.Include(x => x.Lijek);

            var list = query.ToList();
            
            return _mapper.Map<List<Model.NarudzbaStavka>>(list);
        }


        public Model.NarudzbaStavka GetById(int id)
        {
            var entity = _context.NarudzbaStavka
                .Where(x => x.Id == id)
                .Include(x => x.Lijek);

            return _mapper.Map<Model.NarudzbaStavka>(entity.FirstOrDefault());
        }

        public Model.NarudzbaStavka Insert(NarudzbaStavkaInsertRequest request)
        {
            var entity = _mapper.Map<Database.NarudzbaStavka>(request);

            _context.NarudzbaStavka.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.NarudzbaStavka>(entity);
        }

        public Model.NarudzbaStavka Update(int id, NarudzbaStavkaInsertRequest request)
        {
            var result = _context.NarudzbaStavka.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.NarudzbaStavka.Attach(entity);
            _context.NarudzbaStavka.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.NarudzbaStavka>(entity);
        }

    }
}
