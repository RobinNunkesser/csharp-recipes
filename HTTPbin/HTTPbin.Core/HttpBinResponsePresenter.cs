﻿using HTTPbin.Common;

namespace HTTPbin.Core
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