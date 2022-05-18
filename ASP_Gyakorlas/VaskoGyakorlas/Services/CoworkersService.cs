using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VaskoGyakorlas.DTOs;
using VaskoGyakorlas.Models;

namespace VaskoGyakorlas.Services
{
    public class CoworkersService : ICoworkersService
    {
        private readonly AppDbContext _context;

        public CoworkersService(AppDbContext context) => _context = context;

        //Összes coworkers lekérdezése - Include nélkül lazy loading
        public IEnumerable<Coworker> GetAllCoworkers()
        {
            var result = _context.Coworkers.Include(p => p.Phones).Include(n => n.Notebooks);
            return result;
        }

        //Így is lehetne a fenti kód
        //public IEnumerable<Coworker> GetAllCoworkers() => _context.Coworkers.Include(p => p.Phones).Include(n => n.Notebooks);

        //Coworker email alapján
        public Coworker GetCoworkerByEmail(string email)
        {
            var result = _context.Coworkers.Include(p => p.Phones).Include(n => n.Notebooks).Where(n => n.Email == email).FirstOrDefault();
            return result;
        }

        //Email alapján coworker törlése
        public int DeleteCoworkerByEmail(string email)
        {
            var coworker = _context.Coworkers.Where(p => p.Email == email).FirstOrDefault();

            if (coworker != null)
            {
                _context.Coworkers.Remove(coworker);
                var result = _context.SaveChanges();
                System.Console.WriteLine(result);
                return result;
            }
            return 0;
        }

        //Coworker felvitele
        public int AddCoworker(CoworkerDto coworkerDto)
        {
            var check = _context.Coworkers.Where(c => c.Email == coworkerDto.Email).FirstOrDefault();

            if(check is null)
            {
                _context.Coworkers.Add(new Coworker()
                {
                    Name = coworkerDto.Name,
                    Email = coworkerDto.Email
                });

                return _context.SaveChanges();
            }
            return 0;
        }

        //Update
        public int UpdateCoworker(string email, CoworkerDto coworkerDto)
        {
            var check = _context.Coworkers.Where(c => c.Email == email).FirstOrDefault();

            if (check is not null)
            {

                check.Name = coworkerDto.Name;
                check.Email = coworkerDto.Email;

                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        //Coworkernek phone hozzáadása
        public int AddPhone(string email, PhoneDto phoneDto)
        {
            var check = _context.Coworkers.Where(c => c.Email == email).FirstOrDefault();

            if (check is not null)
            {
                _context.Phones.Add(new Phone()
                {
                    Brand = phoneDto.Brand,
                    Type = phoneDto.Type,
                    Coworkerid = check.Id
                });

                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
