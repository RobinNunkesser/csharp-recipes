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
        const string Url = "https://httpbin.org";
        const string MediaTypeJSON = "application/json";

        private HttpClient Client
        {
            get
            {
                var _client = new HttpClient();
                var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
                _client.DefaultRequestHeaders.Accept.Add(media);
                return _client;
            }
        }

        public async Task<Result<HttpBinResponseModel>> Get()
        {
            try
            {
                var httpResponse = await Client.GetAsync($"{Url}/get");
                httpResponse.EnsureSuccessStatusCode();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var result =
                    JsonConvert.DeserializeObject<HttpBinResponseModel>(content);
                return new Result<HttpBinResponseModel>(result);
            }
            catch (System.Exception ex)
            {
                return new Result<HttpBinResponseModel>(ex);
            }
            finally
            {
                Client.Dispose();
            }
        }

        public async Task<Result<HttpBinResponseModel>> Post(string parameters)
        {
            var parametersContent = new StringContent(parameters, Encoding.UTF8, MediaTypeJSON);
            try
            {
                var httpResponse = await Client.PostAsync($"{Url}/post", parametersContent);
                httpResponse.EnsureSuccessStatusCode();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var result =
                    JsonConvert.DeserializeObject<HttpBinResponseModel>(content);
                return new Result<HttpBinResponseModel>(result);
            }
            catch (System.Exception ex)
            {
                return new Result<HttpBinResponseModel>(ex);
            }
            finally
            {
                Client.Dispose();
            }

        }
    }
}
