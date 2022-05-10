using Domain.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Services
{
    public class ContactRepositoy :IContactRepository
    {
        private readonly MyContex _myContex;
        public ContactRepositoy(MyContex myContex)
        {
            _myContex = myContex;
        }

        public void DeleitContact(Contact contact)
        {
            _myContex.Entry(contact).State = EntityState.Deleted;
        }

        public void DelitContactById(int ConatactId)
        {
            var contact = GetContactById(ConatactId);
            DeleitContact(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _myContex.contacts.ToList();
        }

        public Contact GetContactById(int Id)
        {
            return _myContex.contacts.Find(Id);
        }

     

        public List<Contact> GetContactByPersonId(int Personid)
        {
            return _myContex.contacts.Where(p => p.PersonId == Personid).ToList();

        }

        public void InsertContact(Contact contact)
        {

            _myContex.contacts.Add(contact);
        }

        //public void InsertManyContacts(IEnumerable<Contact> contact)
        //{
        //    foreach (var item in contact)
        //    {

        //    }
        //    _myContex.contacts.Add(contact);
        //}

        public int MaximumContactId()
        {
            return _myContex.contacts.Max(p => p.Id);
        }

        public void Save()
        {
            _myContex.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _myContex.Entry(contact).State = EntityState.Modified;
        }
    }
}
