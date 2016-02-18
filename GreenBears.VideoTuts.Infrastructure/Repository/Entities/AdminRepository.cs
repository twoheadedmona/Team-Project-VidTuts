using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Entities
{
    class AdminRepository:IAdminRepository
    {
        DatabaseContext db=new DatabaseContext();
        public Admin Get()
        {
            return db.Admin.First();
        }

        public void Create(Admin newadmin)
        {
            db.Admin.Add(newadmin);
        }

        public void Delete(Admin deleteadmin)
        {
            db.Admin.Remove(deleteadmin);
        }
    }
}
