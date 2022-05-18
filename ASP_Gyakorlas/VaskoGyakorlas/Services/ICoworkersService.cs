using System.Collections.Generic;
using VaskoGyakorlas.DTOs;
using VaskoGyakorlas.Models;

namespace VaskoGyakorlas.Services
{
    public interface ICoworkersService
    {
        IEnumerable<Coworker> GetAllCoworkers();

        Coworker GetCoworkerByEmail(string email);

        int DeleteCoworkerByEmail(string email);

        int AddCoworker(CoworkerDto coworkerDto);

        int UpdateCoworker(string email, CoworkerDto coworkerDto);

        int AddPhone(string email, PhoneDto phoneDto);
    }
}
