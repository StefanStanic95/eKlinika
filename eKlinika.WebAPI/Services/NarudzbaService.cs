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
    public class NarudzbaService : INarudzbaService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public NarudzbaService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Narudzba> Get(NarudzbaSearchRequest request)
        {
            var query = _context.Narudzba.AsQueryable();

            if (request?.DobavljacId != 0)
            {
                query = query.Where(x => x.DobavljacId == request.DobavljacId);
            }

            query = query.Include(x => x.Dobavljac);
            query = query.Include(x => x.NarudzbaStavka);

            List<Database.Narudzba> list = query.ToList();

            List<Model.Narudzba> modelList = _mapper.Map<List<Model.Narudzba>>(list);

            foreach (var item in modelList)
            {
                double iznos = 0;
                foreach (var stavka in item.NarudzbaStavka)
                {
                    Database.Lijek lijek = _context.Lijek.Find(stavka.LijekId);
                    iznos += lijek.CijenaPoKomadu * stavka.Kolicina;
                }
                item.Iznos = iznos;
            }

            return modelList;
        }


        public Model.Narudzba GetById(int id)
        {
            var entity = _context.Narudzba
                .Where(x => x.Id == id)
                .Include(x => x.Dobavljac)
                .Include(x => x.NarudzbaStavka);

            return _mapper.Map<Model.Narudzba>(entity.FirstOrDefault());
        }

        public Model.Narudzba Insert(NarudzbaInsertRequest request)
        {
            var entity = _mapper.Map<Database.Narudzba>(request);

            _context.Narudzba.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Narudzba>(entity);
        }

        public Model.Narudzba Update(int id, NarudzbaInsertRequest request)
        {
            var result = _context.Narudzba.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.Narudzba.Attach(entity);
            _context.Narudzba.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Narudzba>(entity);
        }

    }
}
