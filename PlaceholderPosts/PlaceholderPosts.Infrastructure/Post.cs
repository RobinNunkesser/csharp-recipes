using System.Text.Json.Serialization;

namespace PlaceholderPosts.Infrastructure
{
    public partial class Post
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("body")]
        public string? Body { get; set; }
    }


}