using System;
namespace CleanArchRecipe
{
    public class HttpBinResponseModel
    {
        public string origin { get; set; }
        public string url { get; set; }
        public HttpBinPostRequest json { get; set; }
    }
}
