using System;
namespace CleanArchRecipe
{
    public class ResponseEntity
    {
        public string origin { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"origin: {origin}, url: {url}";
        }
    }
}
