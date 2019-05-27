using BasicCleanArch;

namespace CRUDCleanArch
{
    public class PersonPresenter : IPresenter<PersonEntity, UpdatePageViewModel>
    {
        private string _key;

        public PersonPresenter(string Key)
        {
            _key = Key;
        }

        public UpdatePageViewModel present(PersonEntity entity)
        {
            return new UpdatePageViewModel()
            {
                Key = _key,
                Forename = entity.Forename,
                Surname = entity.Surname
            };
        }
    }
}