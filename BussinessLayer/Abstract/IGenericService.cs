using System.Collections.Generic;

namespace BussinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
