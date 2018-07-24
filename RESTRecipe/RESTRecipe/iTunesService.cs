using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RESTRecipe
{
    public class iTunesService
    {
        const string Url = "https://itunes.apple.com/search";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);
            return client;
        }

        public async Task<string> GetSongs(string term)
        {
            HttpClient client = GetClient();
            try
            {
                UriBuilder builder = new UriBuilder(Url);
                string searchTerm = System.Net.WebUtility.UrlEncode(term);
                builder.Query = $"entity=song&term={searchTerm}&country=de";
                var uri = builder.ToString();
                HttpResponseMessage httpResponse = await client.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();                
            }
            catch (System.Exception ex)
            {
                return ex.Message;                
            } 
            finally {
                client.Dispose();
            }
        }
    }
}
