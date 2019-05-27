using System;
using System.Collections.Generic;

namespace CRUDCleanArch
{
    public sealed class PersonStorageSingleton : IStorageGateway<PersonEntity>
    {
        private static readonly Lazy<PersonStorageSingleton> lazy =
            new Lazy<PersonStorageSingleton>(() =>
                new PersonStorageSingleton());

        private int autoKey = 0;

        private Dictionary<String, PersonEntity> Entities =
            new Dictionary<String, PersonEntity>();

        private PersonStorageSingleton()
        {
            Entities = new Dictionary<String, PersonEntity>();
        }

        public static PersonStorageSingleton Instance => lazy.Value;

        public string Create(PersonEntity obj)
        {
            Entities.Add(autoKey.ToString(), obj);
            return (autoKey++).ToString();
        }

        public PersonEntity Retrieve(string key)
        {
            return Entities.ContainsKey(key) ? Entities[key] : null;
        }

        public ICollection<PersonEntity> RetrieveAll()
        {
            return Entities.Values;
        }

        public bool Update(string key, PersonEntity obj)
        {
            Entities[key] = obj;
            return true;
        }

        public bool Delete(string key)
        {
            Entities.Remove(key);
            return true;
        }
    }
}