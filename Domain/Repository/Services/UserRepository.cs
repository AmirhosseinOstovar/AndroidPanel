using Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Services
{
    public class UserRepository : IUser
    {
        private readonly MyContex _myContext;
        public UserRepository(MyContex myContex)
        {
            _myContext = myContex;
        }
        public bool SingIn(string username, string password)
        {

                if (_myContext.users.Any(P => P.UserName == username && P.Password == password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        
           
        }
    }
}
