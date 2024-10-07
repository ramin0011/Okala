using Crypto.Api.Models;
using FluentValidation;

namespace Crypto.Api.Validations;

public class CryptoQuoteRequestValidator:AbstractValidator<CryptoQuoteRequest>
{
    public CryptoQuoteRequestValidator(IHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            RuleFor(x => x.Code)
                .Equal("EUR").WithMessage("ONLY 'EUR' IS SUPPORTED IN FREE VERSION");
        }
        else
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Crypto code is required.")
                .Matches(@"^[A-Za-z]{3}$").WithMessage("Crypto code must be exactly three letters.");
        }
   
    }
}