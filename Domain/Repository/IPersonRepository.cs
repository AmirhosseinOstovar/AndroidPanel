using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPersonRepository
    {
        public void DelitPerson(Person person);
        public void DelitPersontById(int PersonId);
        public List<Person> GetAllPerson();
        public Person GetPersontById(int Id);
        public int GetidByMail(string Email);
        public int GetIdByPname(string personname);
        public bool SingUp(string email, string password);
        public bool PersonCheck( string email);
        public void InsertPerson(Person person);
        public void Save();
        public void UpdatePerson(Person person);
    }
}
