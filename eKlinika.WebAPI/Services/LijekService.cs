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
    public class LijekService : ILijekService
    {

        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public LijekService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Lijek> Get(LijekSearchRequest request)
        {
            var query = _context.Lijek.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }

            query = query.Include(x => x.Proizvodjac);

            var list = query.ToList();

            return _mapper.Map<List<Model.Lijek>>(list);
        }

        public Model.Lijek GetById(int id)
        {
            var item = _context.Lijek
                .Where(x => x.Id == id)
                .Include(x => x.Proizvodjac);

            return _mapper.Map<Model.Lijek>(item.FirstOrDefault());
        }

        public Model.Lijek Insert(LijekInsertRequest request)
        {
            var entity = _mapper.Map<Database.Lijek>(request);

            _context.Lijek.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Lijek>(entity);
        }

        public Model.Lijek Update(int id, LijekInsertRequest request)
        {
            var result = _context.Lijek.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Lijek.Attach(entity);
                _context.Lijek.Update(entity);

                _mapper.Map(request, entity);

                _context.SaveChanges();

                return _mapper.Map<Model.Lijek>(entity);
            }
    }
}
