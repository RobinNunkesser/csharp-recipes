using System.Collections.Generic;

namespace CRUDCleanArch
{
    public interface IStorageGateway<T>
    {
        string Create(T obj);
        T Retrieve(string key);
        ICollection<T> RetrieveAll();
        bool Update(string key, T obj);
        bool Delete(string key);
    }
}