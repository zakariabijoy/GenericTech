using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public class OrderService : IOrderService
{
    public Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName)
    {
        throw new NotImplementedException();
    }
}
