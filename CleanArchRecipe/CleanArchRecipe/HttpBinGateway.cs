using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CleanArchRecipe.Common;
using Newtonsoft.Json;

namespace CleanArchRecipe
{
    public class HttpBinGateway
    {
        const string Url = "https://httpbin.org/get";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);
            return client;
        }

        public async Task<Response<ResponseEntity>> Get()
        {
            HttpClient client = GetClient();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(Url);
                httpResponse.EnsureSuccessStatusCode();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var result = 
                    JsonConvert.DeserializeObject<ResponseEntity>(content);
                return new Response<ResponseEntity>()
                {
                    Success = result
                };
            }
            catch (System.Exception ex)
            {
                return new Response<ResponseEntity>()
                {
                    Failure = ex
                };
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
