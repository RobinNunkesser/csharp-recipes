using BasicCleanArch;

namespace CleanArchRecipe
{
    public class
        HttpBinResponsePresenter : IPresenter<HttpBinResponseModel, string>
    {
        public string Present(HttpBinResponseModel entity) =>
            entity.Json != null
                ? $"Response: {entity.Json}"
                : $"origin: {entity.Origin}, url: {entity.Url}";
    }
}