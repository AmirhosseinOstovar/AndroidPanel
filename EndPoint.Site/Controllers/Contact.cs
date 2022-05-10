
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Domain.Repository.Services;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class Contact : Controller
    {
        private readonly IContactRepository _contactRepository;
        public Contact(IContactRepository contact)
        {
            _contactRepository = contact;
        }
        
        public IActionResult Index(int PersonId)
        {
            return View(_contactRepository.GetContactByPersonId(PersonId));
        }
       
        
         
      
    }
}
