using System;
using System.Threading.Tasks;
using ExplicitArchitecture;
using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Core
{
    public class GetPostService : IGetPostService
    {
        private readonly IRepository<long, IPost> _repository;

        public GetPostService(IRepository<long, IPost> repository)
        {
            _repository = repository;
        }

        public async Task Execute(IPostID commandDto,
            Action<IPost> successHandler, Action<Exception> errorHandler)
        {
            var result = await _repository.Retrieve(commandDto.Id);
            result.Match(successHandler, errorHandler);
        }
    }
}