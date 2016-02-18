using System.Collections;
using System.Collections.Generic;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository <TGeneric>
    {
        
        void Remove(TGeneric item);
        void Remove(int id);
        void Create(TGeneric newitem);
        void Edit(TGeneric item);
        TGeneric Get(int id);
        List<TGeneric> GetAll();
        void Aproove(int id);
    }
}