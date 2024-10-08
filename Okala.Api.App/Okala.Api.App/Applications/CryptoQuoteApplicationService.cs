using Okala.Api.App.Applications.Core;
using Okala.Api.App.Applications.Dtos;
using Okala.Api.App.Applications.Dtos.CryptoApi;
using Okala.Api.App.Services;

namespace Okala.Api.App.Applications;

public class CryptoQuoteApplicationService(ICryptoService service):AppAppService
{
    public  Task<ResponseModel<CryptoQuote>> GetQuotes(QuotesRequestModel model)
    {
        return service.GetQuotes(model);
    }
}