
namespace Crypto.Base.Models;

public class RequestModel
{
    
    public string CryptoCode { get; set; }
    public string[] AskCodes { get; set; } = new[] { "USD", "EUR", "BRL", "GBP", "AUD" };
}