using PlaceholderPosts.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Infrastructure;

namespace PlaceholderPosts.Console
{
    public class MainView
    {
        private readonly ICommandHandler<GetPostCommandDTO, PostEntity>
            _service = new GetPostCommand(new PostRepositoryAdapter());

        public void Start()
        {
            System.Console.WriteLine("Id of post? ");
            var id = System.Console.ReadLine();
            _service.Execute(new GetPostCommandDTO() {Id = int.Parse(id)},
                System.Console.Write, System.Console.Write);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            System.Console.ReadKey();
        }
    }
}