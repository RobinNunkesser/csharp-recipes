using HTTPbin.Infrastructure;

namespace PlaceholderPosts.Infrastructure
{
    public class JSONPlaceholderAdapter //: IHTTPRequestResponseService
    {
        private JSONPlaceholderAPI _api;

        public JSONPlaceholderAdapter(JSONPlaceholderAPI api) => _api = api;

        public JSONPlaceholderAdapter() => _api = new JSONPlaceholderAPI();
    }
}