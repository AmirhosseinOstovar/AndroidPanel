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
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContex _myContext;
        public PersonRepository(MyContex myContex)
        {
            _myContext = myContex;
        }
        public void DelitPerson(Person person)
        {
            _myContext.Entry(person).State = EntityState.Deleted;
        }

        public void DelitPersontById(int PersonId)
        {
            DelitPerson(GetPersontById(PersonId));
        }

        public List<Person> GetAllPerson()
        {
            return _myContext.person.ToList();
        }

        public int GetidByMail(string Email)
        {
            var p = _myContext.person.Where(p => p.Email == Email).SingleOrDefault();
            if (p.Personid > 0)
            {
                return p.Personid;
            }
            else
            {
                return 0;
            }

        }

        public int GetIdByPname(string personname)
        {

            var p = _myContext.person.Where(p => personname == p.PersonName).SingleOrDefault();
            if (p != null)
            {
                return p.Personid;
            }
            else
            {
                return 0;
            }
        }

        public Person GetPersontById(int Id)
        {
            return _myContext.person.Find(Id);
        }

        public void InsertPerson(Person person)
        {
            _myContext.person.Add(person);
        }

        public bool PersonCheck(string email)
        {
            var p = _myContext.person.Where(p => email == p.Email).SingleOrDefault();
            if (p != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Save()
        {
            _myContext.SaveChanges();
        }

        public bool SingUp(string email, string password)
        {
            var p = _myContext.person.Where(p => email == p.Email && password == p.Password).SingleOrDefault();
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdatePerson(Person person)
        {
            _myContext.Entry(person).State = EntityState.Modified;
        }
    }
}
