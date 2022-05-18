using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VaskoGyakorlas.DTOs;
using VaskoGyakorlas.Models;
using VaskoGyakorlas.Services;

namespace VaskoGyakorlas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkersController : ControllerBase
    {
        private readonly ICoworkersService _coworkersService;

        public CoworkersController(ICoworkersService coworkersService) => _coworkersService = coworkersService;

        [HttpGet]
        [Route("")]
        public IEnumerable<Coworker> GetAllCoworokers()
        {
            var result = _coworkersService.GetAllCoworkers();
            return result;
        }

        [HttpGet("{email}")]
        public Coworker GetCoworokerByEmail(string email)
        {
            var result = _coworkersService.GetCoworkerByEmail(email);
            return result;
        }

        [HttpDelete]
        [Route("{email}")]
        public string DeleteCoworkerByEmail(string email)
        {
            var result = _coworkersService.DeleteCoworkerByEmail(email);

            if(result > 0)
            {
                return "A törlés sikeres";
            }
            return "Sikertelen törlés";
        }

        [HttpPost("AddCoworker")]
        public string AddCoworker(CoworkerDto coworkerDto)
        {
            var result = _coworkersService.AddCoworker(coworkerDto);

            if(result > 0)
            {
                return "Sikeres coworker feltöltés";
            }
            return "Sikertelen coworker feltöltés";
        }

        [HttpPut("UpdateCoworker")]
        public string UpdateCoworker(string email, CoworkerDto coworkerDto)
        {
            var result = _coworkersService.UpdateCoworker(email, coworkerDto);

            if (result > 0)
            {
                return "Sikeres coworker frissítés";
            }
            return "Sikertelen coworker frissítés";
        }

        [HttpPost("AddPhone")]
        public string AddPhone(string email, PhoneDto phoneDto)
        {
            var result = _coworkersService.AddPhone(email, phoneDto);

            if (result > 0)
            {
                return "Sikeres telefon feltöltés";
            }
            return "Sikertelen telefon feltöltés";
        }
    }
}
