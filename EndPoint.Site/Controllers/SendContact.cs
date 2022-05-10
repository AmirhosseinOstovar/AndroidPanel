using Domain.Repository;
using Domain.Repository.Services;
using ContactBackUp.Encryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace EndPoint.Site.Controllers
{

    public class SendContact : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;
        public SendContact(IPersonRepository personRepository, IContactRepository contactRepository)
        {
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }
        public string Index(string personname)
        {
            string Contact = "";
            string fnm = "";
            string num = "";
            Aes myAes = Aes.Create();
            int id = _personRepository.GetIdByPname(personname);
            var contact = _contactRepository.GetContactByPersonId(id);
            var ky = myAes.Key;
            var iv = myAes.IV;
            for (int i = 0; i < contact.Count; i++)
            {
                var Fname = AES.EncryptStringToBytes_Aes(contact[i].FullName, ky, iv);
                var Number = AES.EncryptStringToBytes_Aes(contact[i].PhoneNumber,ky, iv);
                for (int y = 0; y < Fname.Length; y++)
                {
                    fnm += $"[{Fname[y]}]|";
                }
                for (int x = 0; x < Number.Length; x++)
                {
                    num += $"[{Number[x]}]";
                }
               
                Contact += ((fnm+"+")+(num+","));
            }
          //  byte[] en = myAes.e;
           
           // string roundtrip = Decrypt.DecryptStringFromBytes_Aes(en, ky, iv);
           
            return (Contact);

        }
    }
}
