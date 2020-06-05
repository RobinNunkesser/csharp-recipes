using System.Threading.Tasks;
using HTTPbin.Common;

namespace HTTPbin.Core
{
    public interface IHttpBinGateway
    {
        public Task<Result<HttpBinResponseModel>> Get();

        public Task<Result<HttpBinResponseModel>> Post(string parameters);
    }
}