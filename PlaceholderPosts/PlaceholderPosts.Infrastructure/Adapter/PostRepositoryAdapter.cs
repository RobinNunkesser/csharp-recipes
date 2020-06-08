using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTPbin.Infrastructure;
using PlaceholderPosts.Common;
using PlaceholderPosts.Core;

namespace PlaceholderPosts.Infrastructure
{
    public class PostRepositoryAdapter : IRepository<int, PostEntity>
    {
        private readonly JSONPlaceholderAPI _api;

        public PostRepositoryAdapter(JSONPlaceholderAPI api) => _api = api;

        public PostRepositoryAdapter() => _api = new JSONPlaceholderAPI();

        public async Task<Result<int>> Create(PostEntity entity)
        {
            var result = await _api.CreatePost(entity.ToPost());
            return result.ConvertSuccess(post => (int) post.Id);
        }

        public async Task<Result<PostEntity>> Retrieve(int id)
        {
            var result = await _api.ReadPost(id);
            return result.ConvertSuccess(post => post.ToPostEntity());
        }

        public async Task<Result<List<PostEntity>>> RetrieveAll()
        {
            var result = await _api.ReadAllPosts();
            return result.ConvertSuccess(posts =>
                posts.Select(post => post.ToPostEntity()).ToList());
        }

        public Task<Result<bool>> Update(int id, PostEntity entity) =>
            throw new System.NotImplementedException();

        public Task<Result<bool>> Delete(int id) =>
            throw new System.NotImplementedException();
    }
}