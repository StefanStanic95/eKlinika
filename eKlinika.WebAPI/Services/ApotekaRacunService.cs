using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WebAPI.Database;
using eKlinika.WebAPI.Security;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace eKlinika.WebAPI.Services
{
    public class ApotekaRacunService : IApotekaRacunService
    {
        private readonly eKlinikaContext _context;
        private readonly IMapper _mapper;
        public ApotekaRacunService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.ApotekaRacun> Get(ApotekaRacunSearchRequest request)
        {
            var query = _context.ApotekaRacun.AsQueryable();

            if (request?.DatumIzdavanja != null)
            {
                query = query.Where(x => x.DatumIzdavanja.Date == request.DatumIzdavanja.Value.Date);
            }
            if(BasicAuthenticationHandler.korisnik.Pacijent != null)
            {
                query = query.Where(x => x.PacijentId == BasicAuthenticationHandler.korisnik.Id);
            }

            query = query.Include(x => x.Pacijent.Korisnik).Include(x => x.Apotekar.Osoblje.Korisnik);
            query = query.Include(x => x.RacunStavka);

            List<Database.ApotekaRacun> list = query.ToList();

            List<Model.ApotekaRacun> modelList = _mapper.Map<List<Model.ApotekaRacun>>(list);

            foreach (var item in modelList)
            {
                double iznos = 0;
                foreach (var stavka in item.RacunStavka)
                {
                    Database.Lijek lijek = _context.Lijek.Find(stavka.LijekId);
                    iznos += lijek.CijenaPoKomadu * stavka.Kolicina;
                }
                item.Iznos = iznos;
            }

            return modelList;
        }


        public Model.ApotekaRacun GetById(int id)
        {
            var entity = _context.ApotekaRacun
                .Where(x => x.Id == id)
                .Include(x => x.Pacijent.Korisnik)
                .Include(x => x.Apotekar.Osoblje.Korisnik)
                .Include(x => x.RacunStavka);


            return _mapper.Map<Model.ApotekaRacun>(entity.FirstOrDefault());
        }

        public Model.ApotekaRacun Insert(ApotekaRacunInsertRequest request)
        {
            var entity = _mapper.Map<Database.ApotekaRacun>(request);

            _context.ApotekaRacun.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.ApotekaRacun>(entity);
        }

        public Model.ApotekaRacun Update(int id, ApotekaRacunInsertRequest request)
        {
            var result = _context.ApotekaRacun.Where(x => x.Id == id);

            var entity = result.FirstOrDefault();

            _context.ApotekaRacun.Attach(entity);
            _context.ApotekaRacun.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.ApotekaRacun>(entity);
        }

        public object UplataIzvrsena(int Id, string PaymentMethodId)
        {
            var result = _context.ApotekaRacun.Include("RacunStavka.Lijek").Where(x => x.Id == Id);
            var entity = result.FirstOrDefault();
            if (entity == null)
                return null;

            var paymentIntents = new PaymentIntentService();
            long amount = (long)entity.RacunStavka.Sum(x => x.Lijek.CijenaPoKomadu * x.Kolicina);

            try
            {

                var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
                {
                    Amount = amount * 100,
                    PaymentMethod = PaymentMethodId,
                    Confirm = true,
                    Currency = "usd"
                });

                entity.DatumUplate = DateTime.Now;
                _context.SaveChanges();

                return paymentIntent;
            }
            catch (Exception ex)
            {
                return new { Error = ex.Message };
            }
        }
    }
}
