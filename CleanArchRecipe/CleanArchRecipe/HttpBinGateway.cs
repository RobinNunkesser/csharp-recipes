using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BasicCleanArch;
using Newtonsoft.Json;

namespace CleanArchRecipe
{
    public class HttpBinGateway
    {
        private const string Url = "https://httpbin.org";
        private const string MediaTypeJSON = "application/json";

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            client.DefaultRequestHeaders.Accept.Add(media);
            return client;
        }

        public async Task<Result<HttpBinResponseModel>> Get()
        {
            using (var client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync($"{Url}/get");
                    var result = await responseToModel(response);
                    return new Result<HttpBinResponseModel>(result);
                }
                catch (Exception ex)
                {
                    return new Result<HttpBinResponseModel>(ex);
                }
            }
        }

        public async Task<Result<HttpBinResponseModel>> Post(string parameters)
        {
            var parametersContent =
                new StringContent(parameters, Encoding.UTF8, MediaTypeJSON);
            using (var client = GetClient())
            {
                try
                {
                    var response = await client.PostAsync($"{Url}/post",
                        parametersContent);
                    var result = await responseToModel(response);
                    return new Result<HttpBinResponseModel>(result);
                }
                catch (Exception ex)
                {
                    return new Result<HttpBinResponseModel>(ex);
                }
            }
        }

        private async Task<HttpBinResponseModel> responseToModel(
            HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HttpBinResponseModel>(content);
        }
    }
}