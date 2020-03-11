using BasicCleanArch;
namespace MinimalCleanArch
{
    public class MinimalPresenter : IPresenter<int,string>
    {
        public string Present(int entity) => entity.ToString();
    }
}
