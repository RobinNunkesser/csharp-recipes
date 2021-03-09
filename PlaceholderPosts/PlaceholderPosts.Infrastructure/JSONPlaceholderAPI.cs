using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PlaceholderPosts.Common;
using PlaceholderPosts.Infrastructure;

namespace HTTPbin.Infrastructure
{
    public class JSONPlaceholderAPI
    {
        private const string Url = "https://jsonplaceholder.typicode.com";
        private const string MediaTypeJSON = "application/json";

        private static readonly HttpClient HttpClient;

        static JSONPlaceholderAPI()
        {
            HttpClient = new HttpClient() {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            HttpClient.DefaultRequestHeaders.Accept.Add(media);
        }

        public async Task<Result<List<Post>>> ReadAllPosts()
        {
            try
            {
                var posts = await HttpClient.GetFromJsonAsync<List<Post>>("posts");
                return new Result<List<Post>>(posts);
            }
            catch (Exception ex)
            {
                return new Result<List<Post>>(ex);
            }            
        }

        public async Task<Result<Post>> ReadPost(int id)
        {
            try
            {
                var post = await HttpClient.GetFromJsonAsync<Post>($"posts/{id}");
                return new Result<Post>(post);
            }
            catch (Exception ex)
            {
                return new Result<Post>(ex);
            }
        }

        public async Task<Result<Post>> CreatePost(Post post)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync("posts", post);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<Post>(content);
                return new Result<Post>(model);
            }
            catch (Exception ex)
            {
                return new Result<Post>(ex);
            }
        }
    }
}