using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RESTRecipe
{
    public class iTunesService
    {
        const string Url = "https://itunes.apple.com/search";

        public async Task<string> GetSongs(string term)
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);

            try
            {
                var builder = new UriBuilder(Url);
                var searchTerm = WebUtility.UrlEncode(term);
                builder.Query = $"entity=song&term={searchTerm}&country=de";
                var uri = builder.ToString();
                var httpResponse = await client.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();                
            }
            catch (Exception ex)
            {
                return ex.Message;                
            } 
            finally {
                client.Dispose();
            }
        }
    }
}
