using Xunit;

namespace CRUDCleanArch.LocalTests
{
    public class PersonStorageTest
    {
        [Fact]
        public void Create()
        {
            Assert.NotNull(PersonStorageSingleton.Instance.Create(
                new PersonEntity()
                {
                    Forename = "Maria", Surname = "Bernasconi"
                }));
            Assert.NotNull(PersonStorageSingleton.Instance.Create(
                new PersonEntity() {Forename = "Max", Surname = "Mustermann"}));
        }

        [Fact]
        public void Delete()
        {
            var key = PersonStorageSingleton.Instance.Create(
                new PersonEntity()
                {
                    Forename = "Maria", Surname = "Bernasconi"
                });
            Assert.True(PersonStorageSingleton.Instance.Delete(key));
            Assert.Null(PersonStorageSingleton.Instance.Retrieve(key));
        }

        [Fact]
        public void Retrieve()
        {
            var key = PersonStorageSingleton.Instance.Create(
                new PersonEntity()
                {
                    Forename = "Maria", Surname = "Bernasconi"
                });
            var person = PersonStorageSingleton.Instance.Retrieve(key);
            Assert.Equal("Maria", person.Forename);
            Assert.Equal("Bernasconi", person.Surname);
        }

        [Fact]
        public void Update()
        {
            var key = PersonStorageSingleton.Instance.Create(
                new PersonEntity()
                {
                    Forename = "Maria", Surname = "Bernasconi"
                });
            Assert.True(PersonStorageSingleton.Instance.Update(key,
                new PersonEntity()
                {
                    Forename = "Martha", Surname = "Musterfrau"
                }));
            var person = PersonStorageSingleton.Instance.Retrieve(key);
            Assert.Equal("Martha", person.Forename);
            Assert.Equal("Musterfrau", person.Surname);
        }
    }
}