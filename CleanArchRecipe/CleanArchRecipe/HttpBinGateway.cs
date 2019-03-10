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

        public async Task<Result<HttpRequestModel>> Get()
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);

            try
            {
                var httpResponse = await client.GetAsync(Url);
                httpResponse.EnsureSuccessStatusCode();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var result = 
                    JsonConvert.DeserializeObject<HttpRequestModel>(content);
                return new Result<HttpRequestModel>(result);
            }
            catch (System.Exception ex)
            {
                return new Result<HttpRequestModel>(ex);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
