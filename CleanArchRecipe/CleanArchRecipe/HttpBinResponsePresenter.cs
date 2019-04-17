using System;
using BasicCleanArch;

namespace CleanArchRecipe
{
    public class HttpBinResponsePresenter : IPresenter<HttpBinResponseModel, String>
    {
        public string present(HttpBinResponseModel entity)
        {
            return entity.json != null ? 
                $"Response: {entity.json}" : 
                $"origin: {entity.origin}, url: {entity.url}";
        }
    }
}
