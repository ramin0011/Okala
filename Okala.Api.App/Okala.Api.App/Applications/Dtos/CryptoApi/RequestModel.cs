
namespace Okala.Api.App.Applications.Dtos.CryptoApi;

public class RequestModel
{
    
    public string CryptoCode { get; set; }
    public string[] AskCodes { get; set; } = new[] { "USD", "EUR", "BRL", "GBP", "AUD" };
}