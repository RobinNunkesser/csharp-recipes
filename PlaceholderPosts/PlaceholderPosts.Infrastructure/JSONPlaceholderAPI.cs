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


        private async Task<Result<T>> Read<T>(string requestUri)
        {
            using var client = GetClient();
            try
            {
                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(content);
                return new Result<T>(model);
            }
            catch (Exception ex)
            {
                return new Result<T>(ex);
            }
        }

        public async Task<Result<List<Post>>> ReadAllPosts()
        {
            var result = Read<List<Post>>($"{Url}/posts");
            return await result;
        }

        public async Task<Result<Post>> ReadPost(int id)
        {
            var result = Read<Post>($"{Url}/posts/{id}");
            return await result;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            client.DefaultRequestHeaders.Accept.Add(media);
            return client;
        }
    }
}