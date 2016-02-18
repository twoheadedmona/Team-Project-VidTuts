using GreenBears.VideoTuts.Core.Entities;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Admin Get();
        void Create(Admin newadmin);
        void Delete(Admin deleteadmin);
    }
}