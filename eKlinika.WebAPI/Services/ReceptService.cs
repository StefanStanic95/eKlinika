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
    public class ReceptService : IReceptService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public ReceptService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Recept> Get(ReceptSearchRequest request)
        {
            var query = _context.Recept.AsQueryable();

            if (request?.DatumIzdavanja != null)
            {
                query = query.Where(x => x.DatumIzdavanja.Date == request.DatumIzdavanja.Value.Date);
            }

            query = query.Include(x => x.Lijek).Include(x => x.Pregled);

            var list = query.ToList();

            return _mapper.Map<List<Model.Recept>>(list);
        }

        public Model.Recept GetById(int id)
        {
            var item = _context.Recept
                .Include(x => x.Lijek)
                .Include(x => x.Pregled)
                .Where(x => x.Id == id);

            return _mapper.Map<Model.Recept>(item.FirstOrDefault());
        }

        public Model.Recept Insert(ReceptInsertRequest request)
        {
            var entity = _mapper.Map<Database.Recept>(request);

            _context.Recept.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Recept>(entity);
        }

        public Model.Recept Update(int id, ReceptInsertRequest request)
        {
            var result = _context.Recept.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Recept.Attach(entity);
            _context.Recept.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Recept>(entity);
        }
    }
}
