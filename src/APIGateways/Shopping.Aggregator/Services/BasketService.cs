using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public class BasketService : IBasketService
{
    public async Task<BasketDto> GetBasket(string userName)
    {
        throw new NotImplementedException();
    }
}