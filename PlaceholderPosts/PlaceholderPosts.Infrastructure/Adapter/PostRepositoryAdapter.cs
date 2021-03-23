using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExplicitArchitecture;
using HTTPbin.Infrastructure;
using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Infrastructure
{
    public class PostRepositoryAdapter : IRepository<long, IPost>
    {
        private readonly JSONPlaceholderAPI _api;

        public PostRepositoryAdapter(JSONPlaceholderAPI api) => _api = api;

        public PostRepositoryAdapter() => _api = new JSONPlaceholderAPI();

        public async Task<Result<long>> Create(IPost entity)
        {
            var result = await _api.CreatePost(
                new Post() {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Title = entity.Title,
                    Body = entity.Body
                });
            return result.Map(post => (long) post.Id);
        }

        public async Task<Result<IPost>> Retrieve(long id)
        {
            var result = await _api.ReadPost(id);
            return result.Map(post => (IPost)post);
        }

        public async Task<Result<List<IPost>>> RetrieveAll()
        {
            var result = await _api.ReadAllPosts();
            return result.Map(posts =>
                posts.Select(post => (IPost)post).ToList());
        }

        public Task<Result<bool>> Update(long id, IPost entity) =>
            throw new System.NotImplementedException();

        public Task<Result<bool>> Delete(long id) =>
            throw new System.NotImplementedException();
    }
}