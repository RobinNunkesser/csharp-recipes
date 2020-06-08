using PlaceholderPosts.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Infrastructure;

namespace PlaceholderPosts.Console
{
    public class MainView
    {
        private readonly IAppService<PostRequest, PostEntity> _service =
            new GetPostService(new PostRepositoryAdapter());

        public void Start()
        {
            System.Console.WriteLine("Term to post? ");
            var id = System.Console.ReadLine();
            _service.Execute(new PostRequest() {Id = int.Parse(id)},
                System.Console.Write, System.Console.Write);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            System.Console.ReadKey();
        }
    }
}