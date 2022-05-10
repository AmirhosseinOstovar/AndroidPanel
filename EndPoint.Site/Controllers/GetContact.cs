using Domain.Repository;
using Domain.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class GetContact : Controller
    {

        private readonly IContactRepository _contactRepository;
        private readonly IPersonRepository _personRepository;
        public GetContact(IContactRepository contact,IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _contactRepository = contact;
        }

        public void Index(string personname, string Ncontact)
        {
            string[] cont = Ncontact.Split(",");
           
           
            var person = _personRepository.GetPersontById(_personRepository.GetIdByPname(personname));
            var Count = cont.Length / 2;
            int C = 0;
            int Y = 1;
            for (int i = 1; i <= Count; i++)


            {
                Domain.Entity.Contact contact = new Domain.Entity.Contact()
                {
                    FullName = cont[C],
                    PhoneNumber = cont[Y],
                    Person = person
                };

                _contactRepository.InsertContact(contact);
                C += 2;
                Y += 2;
            }



            _contactRepository.Save();

          
        }
        

    }


}
