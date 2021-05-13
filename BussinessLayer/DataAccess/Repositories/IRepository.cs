using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.DataAccess.Repositories
{
    interface IRepository<T,K> where T:class where K : IConvertible
    {
        void Create(T newEntry);
        T Read(int key);
        List<T> ReadAll();
        void Delete(K key);
        void Update(T updatedEntry);
        List<T> Find(string index);
    }
}
