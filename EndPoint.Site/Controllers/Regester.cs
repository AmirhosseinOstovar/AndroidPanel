using Domain.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class Regester : Controller
    {
        private readonly IPersonRepository _personRepository;
        public Regester(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public bool SingUp(string PersonName, string email, string password)
        {

            if (_personRepository.PersonCheck(email) == true)
            {
                Domain.Entity.Person p = new Domain.Entity.Person()
                {

                    PersonName = PersonName,
                    Email = email,
                    Password = password

                };
                _personRepository.InsertPerson(p);
                _personRepository.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SingIn (string email,string password)
        {

            return _personRepository.SingUp(email, password);
        }
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
           await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
