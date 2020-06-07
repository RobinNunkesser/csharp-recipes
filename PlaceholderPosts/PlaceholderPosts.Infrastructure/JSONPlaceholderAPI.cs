using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlaceholderPosts.Common;
using PlaceholderPosts.Infrastructure;

namespace HTTPbin.Infrastructure
{
    public class JSONPlaceholderAPI
    {
        private const string Url = "https://jsonplaceholder.typicode.com";
        private const string MediaTypeJSON = "application/json";

        public async Task<Result<List<Post>>> ReadAllPosts()
        {
            using var client = GetClient();
            try
            {
                var response = await client.GetAsync($"{Url}/posts");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<Post>>(content);
                return new Result<List<Post>>(model);
            }
            catch (Exception ex)
            {
                return new Result<List<Post>>(ex);
            }
        }

        public async Task<Result<Post>> ReadPost(int id)
        {
            using var client = GetClient();
            try
            {
                var response = await client.GetAsync($"{Url}/posts/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Post>(content);
                return new Result<Post>(model);
            }
            catch (Exception ex)
            {
                return new Result<Post>(ex);
            }
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            client.DefaultRequestHeaders.Accept.Add(media);
            return client;
        }

        private async Task<List<Post>> responseToModel(
            HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content);
        }
    }
}