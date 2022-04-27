using EszkozNyilvantartoApi.DTO;
using EszkozNyilvantartoApi.Models;
using EszkozNyilvantartoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EszkozNyilvantartoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkerController : ControllerBase
    {
        private readonly CoworkerService coworkerServices;

        public CoworkerController(CoworkerService coworkerServices)
        {
            this.coworkerServices = coworkerServices;
        }

        [HttpGet]
        [Route("getCoworkerByEmail/{email}")]
        public Coworker GetCoworkerByEmail(string email)
        {
            return coworkerServices.GetCoworkerByEmail(email);
        }

        [HttpGet]
        [Route("numberOfCoworkers")]
        
        public int GetNumberOfCoworkers()
        {
            return coworkerServices.GetNumberOfCoworkers();
        }

        [HttpPost]
        [Route("addPhone")]

        public string AddPhoneToCoworker(PhoneDTO phone)
        {
            var result = coworkerServices.AddPhoneToCoworker(phone);

            if(result > 0)
            {
                return "Sikeres";
            }
            else
            {
                return "Sikertelen";
            }
        }
    }
}
