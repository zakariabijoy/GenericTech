namespace Shopping.Aggregator.Dtos;

public class ShoppingDto
{
    public string UserName { get; set; }
    public BasketDto BasketWithProducts { get; set; }
    public IEnumerable<OrderResponseDto> Orders { get; set; }
}
