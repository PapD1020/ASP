using EszkozNyilvantartoApi.DTO;
using EszkozNyilvantartoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EszkozNyilvantartoApi.Services
{
    public class CoworkerService
    {
        private readonly eszkoz_nyilvantartoContext context;

        public CoworkerService(eszkoz_nyilvantartoContext context)
        {
            this.context = context;
        }

        public Coworker GetCoworkerByEmail(string email)
        {
            return context.Coworkers.First(Coworker => Coworker.Email == email);
        }

        public int GetNumberOfCoworkers()
        {
            return context.Coworkers.Count();
        }

        public int AddPhoneToCoworker(PhoneDTO phone)
        {
            if(phone is not null)
            {
                context.Phones.Add(new Phone() { PhoneCoworkerId = phone.PhoneCoworkerId, Brand = phone.Brand, Type = phone.Type });
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

    }
}
