using System;
using PlaceholderPosts.Common;

namespace PlaceholderPosts.Core
{
    public class GetPostService : IAppService<PostRequest, PostEntity>
    {
        private readonly IRepository<int, PostEntity> _repository;

        public GetPostService(IRepository<int, PostEntity> repository)
        {
            _repository = repository;
        }

        public async void Execute(PostRequest request,
            Action<PostEntity> successHandler, Action<Exception> errorHandler)
        {
            var result = await _repository.Retrieve(request.Id);
            result.Match(successHandler, errorHandler);
        }
    }
}