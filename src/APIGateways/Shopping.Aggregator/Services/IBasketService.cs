using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public interface IBasketService
{
    Task<BasketDto> GetBasket(string userName);
}
