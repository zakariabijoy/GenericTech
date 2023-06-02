using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Dtos;
using Shopping.Aggregator.Services;

namespace Shopping.Aggregator.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ShoppingController : ControllerBase
{
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;

    public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
    {
        _catalogService = catalogService;
        _basketService = basketService;
        _orderService = orderService;
    }

    [HttpGet("{userName}", Name = "GetShopping")]
    [ProducesResponseType(typeof(ShoppingDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingDto>> GetShopping(string userName)
    {
        // get basket with username
        // iterate basket items and consume products with basket item productId member
        // map product related members into basketitem dto with extended columns
        // consume ordering microservices in order to retrive order list
        // return root shoppingDto class which including all responses

        var basket = await _basketService.GetBasket(userName);

        foreach (var basketItem in basket.Items)
        {
            var product = await _catalogService.GetCatalog(basketItem.ProductId);

            //set additional product properties onto basket item
            basketItem.ProductName = product.Name;
            basketItem.Category = product.Category;
            basketItem.Summary = product.Summary;
            basketItem.Description = product.Description;
            basketItem.ImageFile = product.ImageFile;
        }

        var orders = await _orderService.GetOrdersByUserName(userName);

        return Ok(new ShoppingDto
        {
            UserName = userName,
            BasketWithProducts = basket,
            Orders = orders
        });
    }
}
