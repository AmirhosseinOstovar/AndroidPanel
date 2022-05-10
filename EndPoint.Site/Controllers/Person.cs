using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class Person : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUser _user;

        public Person(IPersonRepository personRepository, IUser user)
        {
            _personRepository = personRepository;
            _user = user;

        }

        public IActionResult Index()
        {
            return View(_personRepository.GetAllPerson());
        }
        public void DelitPerson(int Personid)
        {
            _personRepository.DelitPersontById(Personid);
        }
        //public IActionResult editePerson()
        //{
        //    return View();
        //}
        //public IActionResult EditPerson(Domain.Entity.Person person)
        //{
        //    _personRepository.UpdatePerson(person);
        //    _personRepository.Save();
        //}
     
    }
}
