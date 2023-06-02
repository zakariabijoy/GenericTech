using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName);
}
