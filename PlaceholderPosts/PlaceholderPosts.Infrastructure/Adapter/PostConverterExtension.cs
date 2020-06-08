using PlaceholderPosts.Core;

namespace PlaceholderPosts.Infrastructure
{
    public static class Convert
    {
        public static PostEntity ToPostEntity(this Post self) =>
            new PostEntity()
            {
                UserId = (int) self.UserId,
                Id = (int) self.Id,
                Title = self.Title,
                Body = self.Body
            };

        public static Post ToPost(this PostEntity self) =>
            new Post()
            {
                UserId = self.UserId,
                Id = self.Id,
                Title = self.Title,
                Body = self.Body
            };
    }
}