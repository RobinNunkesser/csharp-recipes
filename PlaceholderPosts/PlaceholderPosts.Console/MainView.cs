using ExplicitArchitecture;
using PlaceholderPosts.Core;
using PlaceholderPosts.Core.Ports;
using PlaceholderPosts.Infrastructure;

namespace PlaceholderPosts.Console
{
    public class MainView
    {
        private readonly IService<IPostID, IPost>
            _service = new GetPostService(new PostRepositoryAdapter());

        public void Start()
        {
            System.Console.WriteLine("Id of post? ");
            var id = System.Console.ReadLine();
            _service.Execute(new GetPostServiceDTO() {Id = int.Parse(id)},
                System.Console.Write, System.Console.Write);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            System.Console.ReadKey();
        }
    }
}