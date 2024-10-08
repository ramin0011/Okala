using Okala.Api.App.Applications.Dtos;
using Okala.Api.App.Applications.Dtos.CryptoApi;

namespace Okala.Api.App.Services;

public interface ICryptoService
{
    Task<ResponseModel<CryptoQuote>> GetQuotes(QuotesRequestModel model);
}