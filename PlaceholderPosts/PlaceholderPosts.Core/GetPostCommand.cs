using System;
using System.Threading.Tasks;
using PlaceholderPosts.Common;

namespace PlaceholderPosts.Core
{
    public class GetPostCommand : ICommandHandler<GetPostCommandDTO, PostEntity>
    {
        private readonly IRepository<int, PostEntity> _repository;

        public GetPostCommand(IRepository<int, PostEntity> repository)
        {
            _repository = repository;
        }

        public async Task Execute(GetPostCommandDTO commandDto,
            Action<PostEntity> successHandler, Action<Exception> errorHandler)
        {
            var result = await _repository.Retrieve(commandDto.Id);
            result.Match(successHandler, errorHandler);
        }
    }
}