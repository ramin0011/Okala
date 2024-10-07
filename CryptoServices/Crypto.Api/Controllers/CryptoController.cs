using Crypto.Api.Discovery;
using Crypto.Api.Models;
using Crypto.Base.Enums;
using Crypto.Base.Models;
using Crypto.Base.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController(IEnumerable<ICryptoQuoteService> services) : ControllerBase
    {
        [HttpPost(Name = "GetQuotes")]
        public Task<ResponseModel<CryptoQuote>> Post(CryptoQuoteRequest request)
        {
            var cryptoService = services.FindCryptoService(ProviderType.ExchangeRate);
            var requestModel = new RequestModel(){CryptoCode = request.Code};
            return cryptoService.GetQuotes(requestModel);
        }
    }
}
