using System.ComponentModel.DataAnnotations;

namespace Crypto.Api.Models;

public class CryptoQuoteRequest
{
    public string Code { get; set; }
}