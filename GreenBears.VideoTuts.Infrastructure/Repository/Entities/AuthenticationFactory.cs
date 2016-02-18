using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Entities
{
    public enum AuthStatus { Done, Error}
    public class AuthentificationFactory
    {
        private UserRepository userRepo = new UserRepository();
        public AuthStatus LogIn(string username, string password)
        {
            var user = userRepo.GetAll().FirstOrDefault(x => x.Username==username && x.Password == password);
            if (user == null || !user.IsAproved) return AuthStatus.Error;
            return AuthStatus.Done;
            
        }
    }
}
