namespace CleanArchRecipe.Common
{
    public interface IPresenter<Entity,ViewModel>
    {
        ViewModel present(Entity entity);
    }
}