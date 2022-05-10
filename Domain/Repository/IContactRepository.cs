using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Services
{
    public interface IContactRepository
    {
        public void DeleitContact(Contact contact);
        public void DelitContactById(int ConatactId);
        public List<Contact> GetAllContacts();
        public Contact GetContactById(int Id);
        public List<Contact> GetContactByPersonId(int Personid);
        public void InsertContact(Contact contact);
        public int MaximumContactId();
        public void Save();
        public void UpdateContact(Contact contact);
     }
}
