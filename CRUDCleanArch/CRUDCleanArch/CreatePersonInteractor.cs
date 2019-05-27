using System;
using BasicCleanArch;

namespace CRUDCleanArch
{
    public class CreatePersonInteractor : IUseCase<CreatePersonRequest, String>
    {
        public void Execute(CreatePersonRequest request,
            IDisplayer<string> outputBoundary)
        {
            var key = PersonStorageSingleton.Instance.Create(new PersonEntity()
            {
                Forename = request.Forename, Surname = request.Surname
            });

            outputBoundary.Display(new Result<string>(key));
        }
    }
}