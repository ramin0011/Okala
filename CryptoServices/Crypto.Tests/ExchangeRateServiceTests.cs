using AutoMapper;
using Crypto.Base.Models;
using Crypto.Exchangerates.Helpers;
using Crypto.Shared.Configurations;
using Crypto.Shared.Models.ExchangeRate;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;

namespace Crypto.Exchangerates.Tests
{
    public class ExchangeRateServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IOptions<ProvidersKeys>> _optionsMock;
        private readonly Mock<IExchageRateApiHelper> _apiHelperMock;
        private readonly Service _service;

        public ExchangeRateServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _optionsMock = new Mock<IOptions<ProvidersKeys>>();
            _apiHelperMock = new Mock<IExchageRateApiHelper>();

            var providerKeys = new ProvidersKeys { ExchangeRateApiKey = "test_api_key" };
            _optionsMock.Setup(o => o.Value).Returns(providerKeys);

            _service = new Service(_mapperMock.Object, _optionsMock.Object, _apiHelperMock.Object);
        }

        [Fact]
        public async Task GetQuotes_ReturnsSuccessfulResponse()
        {
            // Arrange
            var request = new RequestModel();
            var client = new RestClient(); 
            var apiResult = new ApiResponse() { Success = true };
            var quotes = new CryptoQuote();

            _apiHelperMock.Setup(a => a.GetRestClient(It.IsAny<string>(), It.IsAny<RequestModel>())).Returns(client);
            _apiHelperMock.Setup(a => a.GetQuotes(client, _mapperMock.Object)).ReturnsAsync((apiResult, quotes));

            // Act
            var response = await _service.GetQuotes(request);

            // Assert
            Assert.True(response.IsSuccessful);
            Assert.Equal(quotes, response.Result);
            Assert.Null(response.ErrorCode);
            Assert.Null(response.ErrorDescription);
        }

        [Fact]
        public async Task GetQuotes_ReturnsErrorResponse()
        {
            // Arrange
            var request = new RequestModel();
            var client = new RestClient(); 
            var apiResult = new ApiResponse { Success = false, Error = new Error() { Code = "error_code", Message = "error_message" } };
            var quotes = new CryptoQuote();

            _apiHelperMock.Setup(a => a.GetRestClient(It.IsAny<string>(), It.IsAny<RequestModel>())).Returns(client);
            _apiHelperMock.Setup(a => a.GetQuotes(client, _mapperMock.Object)).ReturnsAsync((apiResult, quotes));

            // Act
            var response = await _service.GetQuotes(request);

            // Assert
            Assert.False(response.IsSuccessful);
            Assert.Equal("error_code", response.ErrorCode);
            Assert.Equal("error_message", response.ErrorDescription);
        }
    }
}
