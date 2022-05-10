
using sun.security.util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
