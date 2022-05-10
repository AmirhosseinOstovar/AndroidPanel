using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
   public class MyContex:DbContext
    {
       
    
        public MyContex(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Contact> contacts { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<Users> users{ get; set; }

    }
}
