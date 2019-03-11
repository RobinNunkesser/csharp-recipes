using System;
using BasicCleanArch;

namespace CleanArchRecipe
{
    public class HttpRequestPresenter : IPresenter<HttpRequestModel,String>
    {
        public string present(HttpRequestModel entity)
        {
            return $"origin: {entity.origin}, url: {entity.url}";
        }
    }
}
