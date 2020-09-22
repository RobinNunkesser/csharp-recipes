using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
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

        private static readonly HttpClient HttpClient;

        static JSONPlaceholderAPI()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == SslPolicyErrors.None) return true;
                    return sender.RequestUri.Host ==
                           "jsonplaceholder.typicode.com";
                };
            HttpClient = new HttpClient(handler);
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            HttpClient.DefaultRequestHeaders.Accept.Add(media);
        }

        private async Task<Result<T>> UseClientAsync<T>(
            HttpRequestMessage message)
        {
            try
            {
                var response = await HttpClient.SendAsync(message);
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
            var message =
                new HttpRequestMessage(HttpMethod.Get, $"{Url}/posts");
            var result = UseClientAsync<List<Post>>(message);
            return await result;
        }

        public async Task<Result<Post>> ReadPost(int id)
        {
            var message =
                new HttpRequestMessage(HttpMethod.Get, $"{Url}/posts/{id}");
            var result = UseClientAsync<Post>(message);
            return await result;
        }

        public async Task<Result<Post>> CreatePost(Post post)
        {
            var jsonPost = JsonConvert.SerializeObject(post);
            var message =
                new HttpRequestMessage(HttpMethod.Post, $"{Url}/posts")
                {
                    Content = new StringContent(jsonPost, Encoding.UTF8,
                        MediaTypeJSON)
                };
            var result = UseClientAsync<Post>(message);
            return await result;
        }
    }
}