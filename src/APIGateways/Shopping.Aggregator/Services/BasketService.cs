using Shopping.Aggregator.Dtos;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BasketDto> GetBasket(string userName)
    {
        var response = await _httpClient.GetAsync($"/api/v1/Basket/{userName}");
        return await response.ReadcontentAs<BasketDto>();
    }
}