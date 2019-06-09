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
using eKlinika.WebAPI.Exceptions;

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

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query = query.Where(x => (x.Ime + " " + x.Prezime).Contains(request.ImePrezime));
            }
            query = IncludeUserDetails(query);

            if (!string.IsNullOrWhiteSpace(request?.Uloga))
            {
                query = query.Where(x => x.KorisniciUloge.Where(y => y.Uloga.Naziv == request.Uloga).Any());
            }


            var list = query.ToList();

            return _mapper.Map<List<Model.Korisnici>>(list);
        }

        private static IQueryable<Korisnici> IncludeUserDetails(IQueryable<Korisnici> query)
        {
            return query
                .Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga)
                .Include(x => x.Pacijent).ThenInclude(x => x.KrvnaGrupa)
                .Include(x => x.Osoblje).ThenInclude(x => x.Apotekar)
                .Include(x => x.Osoblje).ThenInclude(x => x.Doktor)
                .Include(x => x.Osoblje).ThenInclude(x => x.MedicinskaSestra);
        }

        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Where(x => x.Id == id);
            entity = IncludeUserDetails(entity);

            return _mapper.Map<Model.Korisnici>(entity.FirstOrDefault());
        }


        public Model.Korisnici GetMe()
        {
            var entity = _context.Korisnici.Where(x => x.Id == BasicAuthenticationHandler.korisnik.Id);
            entity = IncludeUserDetails(entity);

            return _mapper.Map<Model.Korisnici>(entity.FirstOrDefault());
        }


        public Model.Korisnici GetByEmail(string email)
        {
            var entity = _context.Korisnici.Where(x => x.Email == email);
            entity = IncludeUserDetails(entity);

            return _mapper.Map<Model.Korisnici>(entity.FirstOrDefault());
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge
                {
                    KorisnikId = entity.Id,
                    UlogaId = uloga
                };
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici UpdatePacijent(int id, PacijentUpdateRequest request)
        {
            if (id != BasicAuthenticationHandler.korisnik.Id)
                return null;

            var result = _context.Korisnici.Where(x => x.Id == BasicAuthenticationHandler.korisnik.Id);
            result = IncludeUserDetails(result);

            var entity = result.FirstOrDefault();

            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new UserException("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            if(request.Pacijent1 != null)
            {
                entity.Pacijent.Alergije = request.Pacijent1.Alergije;
                entity.Pacijent.Tezina = request.Pacijent1.Tezina;
                entity.Pacijent.Visina = request.Pacijent1.Visina;
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var result = _context.Korisnici.Where(x => x.Id == id);
            result = IncludeUserDetails(result);

            var entity = result.FirstOrDefault();

            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new UserException("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            if(request.Pacijent1 != null)
            {
                entity.Pacijent.Alergije = request.Pacijent1.Alergije;
                entity.Pacijent.BrojKartona = request.Pacijent1.BrojKartona;
                entity.Pacijent.BrojKnjizice = request.Pacijent1.BrojKnjizice;
                entity.Pacijent.DatumRegistracije = request.Pacijent1.DatumRegistracije;
                entity.Pacijent.KrvnaGrupaId = request.Pacijent1.KrvnaGrupaId;
                entity.Pacijent.SpecijalniZahtjevi = request.Pacijent1.SpecijalniZahtjevi;
                entity.Pacijent.Tezina = request.Pacijent1.Tezina;
                entity.Pacijent.Visina = request.Pacijent1.Visina;
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Authenticiraj(string username, string pass)
        {
            var result = _context.Korisnici.Where(x => x.UserName == username);
            result = IncludeUserDetails(result);

            var user = result.FirstOrDefault();
            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }
            return null;
        }


        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

    }
}
