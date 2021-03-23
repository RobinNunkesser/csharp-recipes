using System;
using ExplicitArchitecture;

namespace PlaceholderPosts.Core.Ports
{
    public interface IGetPostService : IService<IPostID, IPost>
    {
    }
}
