using BasicCleanArch;
namespace MinimalCleanArch
{
    public class MinimalPresenter : IPresenter<int,string>
    {
        public string present(int entity) => entity.ToString();
    }
}
