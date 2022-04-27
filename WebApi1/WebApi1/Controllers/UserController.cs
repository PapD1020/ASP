using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi1.Data;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Data.User> Get(int id)
        {
            //Mind a mydbcontext-ben a Users változó
            List<User> Users = new List<User>();

            using(var context = new MyDbContext())
            {
                try
                {
                    //return context.Users.ToList();
                    List<Data.User> u = new List<Data.User>(context.Users.Where(felh => felh.Id == id));
                    return u;
                }
                catch
                {

                }
            }

            return Users;
        }

        [HttpPost]
        public string Post(string bNev, string jelszo, string fNev, int jog, int aktiv)
        {
            //User user = new User(0, bNev, jelszo, fNev, jog, aktiv);
            //Másik verzió
            User user = new User();
            user.BNev = bNev;
            user.Jelszo = jelszo;
            user.FNev = fNev;
            user.Jog = jog;
            user.Aktiv = aktiv;

            using(var context = new MyDbContext())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                    if (e.Message.Substring(0,8)=="An error")
                    {
                        return "This becenéb is already in use.";
                    }
                    else
                    {
                        return "Error while connecting to SQL databse.";
                    }
                }
            }

            return "The user was added successfully!";
        }
    }
}
