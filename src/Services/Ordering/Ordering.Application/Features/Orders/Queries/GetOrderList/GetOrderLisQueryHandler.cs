using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList;

public class GetOrderLisQueryHandler : IRequestHandler<GetOrderLisQuery, List<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderLisQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<OrderDto>> Handle(GetOrderLisQuery request, CancellationToken cancellationToken) => _mapper.Map<List<OrderDto>>(await _orderRepository.GetOrdersByUserName(request.Username));
}
