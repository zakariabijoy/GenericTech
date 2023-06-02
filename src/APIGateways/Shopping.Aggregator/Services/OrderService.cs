using Shopping.Aggregator.Dtos;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName)
    {
        var response = await _httpClient.GetAsync($"/api/v1/Order/{userName}");
        return await response.ReadcontentAs<List<OrderResponseDto>>();
    }
}
