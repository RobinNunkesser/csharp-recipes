using BasicCleanArch;

namespace CleanArchRecipe
{
    public class
        HttpBinResponsePresenter : IPresenter<HttpBinResponseModel, string>
    {
        public string Present(HttpBinResponseModel entity) =>
            entity.json != null
                ? $"Response: {entity.json}"
                : $"origin: {entity.Origin}, url: {entity.Url}";
    }
}