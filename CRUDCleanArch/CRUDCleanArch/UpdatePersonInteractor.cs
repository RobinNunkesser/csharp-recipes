using BasicCleanArch;

namespace CRUDCleanArch
{
    public class UpdatePersonInteractor : IUseCase<UpdatePersonRequest, bool>
    {
        public void Execute(UpdatePersonRequest request,
            IDisplayer<bool> outputBoundary)
        {
            var result = PersonStorageSingleton.Instance.Update(request.Key,
                new PersonEntity()
                {
                    Forename = request.Forename, Surname = request.Surname
                });

            outputBoundary.Display(new Result<bool>(result));
        }
    }
}