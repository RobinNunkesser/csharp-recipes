using System;
using TuneSearch.Common;

namespace CleanArchRecipe
{
    public class ResponsePresenter : IPresenter<ResponseEntity,String>
    {
        public string present(ResponseEntity entity)
        {
            return $"origin: {entity.origin}, url: {entity.url}";
        }
    }
}
