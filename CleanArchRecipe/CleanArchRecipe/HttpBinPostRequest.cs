using System;
namespace CleanArchRecipe
{
    public class HttpBinPostRequest
    {
        public string term { get; set; }

        public override string ToString()
        {
            return term;
        }
    }
}
