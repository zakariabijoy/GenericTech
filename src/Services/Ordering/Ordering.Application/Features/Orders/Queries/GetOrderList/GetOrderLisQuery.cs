using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList;

public class GetOrderLisQuery : IRequest<List<OrderDto>>
{
    public string Username { get; set; }

    public GetOrderLisQuery(string userName)
    {
        Username = userName ?? throw new ArgumentNullException(nameof(userName)) ;
    }
}
