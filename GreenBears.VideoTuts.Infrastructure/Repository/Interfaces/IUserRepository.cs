using GreenBears.VideoTuts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {

        User GetByUsername(string username);
        User GetByEmail(string email);
        
        User GetCurrent();
    }
}
