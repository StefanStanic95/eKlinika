using AutoMapper;
using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public class ProizvodjacService : IProizvodjacService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public ProizvodjacService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Proizvodjac> Get(ProizvodjacSearchRequest request)
        {
            var query = _context.Proizvodjac.AsQueryable();

            if (request?.Naziv != null)
            {
                query = query.Where(x => x.Naziv == request.Naziv);
            }

            var list = query
                .ToList();

            return _mapper.Map<List<Model.Proizvodjac>>(list);
        }


        public Model.Proizvodjac GetById(int id)
        {
            var entity = _context.Proizvodjac.Where(x => x.Id == id);

            return _mapper.Map<Model.Proizvodjac>(entity.FirstOrDefault());
        }

        public Model.Proizvodjac Insert(Model.Proizvodjac request)
        {
            var entity = _mapper.Map<Database.Proizvodjac>(request);

            _context.Proizvodjac.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodjac>(entity);
        }


        public Model.Proizvodjac Update(int id, Model.Proizvodjac request)
        {
            var result = _context.Proizvodjac.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Proizvodjac.Attach(entity);
            _context.Proizvodjac.Update(entity);

            _mapper.Map(request, entity);


            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodjac>(entity);
        }

    }
}
