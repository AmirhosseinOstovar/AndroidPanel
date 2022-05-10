using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Person
    {
        
        [Key]
        public int Personid { get; set; }
        public string PersonName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Contact> contacts { get; set; }
    }
}
