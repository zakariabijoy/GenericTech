using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountGrpcService _discountGrpcService;
    private readonly IMapper _mapper;

    public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService, IMapper mapper)
    {
        _basketRepository = basketRepository;
        _discountGrpcService = discountGrpcService;
        _mapper = mapper;
    }

    [HttpGet("{userName}", Name ="GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName) => Ok(await _basketRepository.GetBasket(userName)?? new ShoppingCart(userName));

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
        //TODO: Communicate with Discount.Grpc
        //and Calculate latest prices of product into shopping cart.
        
        foreach (var item in basket.Items)
        {
            //consume Discount Grpc
            var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;

        }

        return Ok(await _basketRepository.UpdateBasket(basket));
    }

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await _basketRepository.DeleteBasket(userName);
        return Ok();
    }

    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        //ToDo:
        // get existing basket with total price
        // create basketCheckoutEvent -- set TotalPrice on basketcheckout eventMessage
        // send checkout event to rbbitmq
        // remove the basket     

        // get existing basket with total price
        var basket = await _basketRepository.GetBasket(basketCheckout.UserName);
        if(basket is null)
        {
            return BadRequest();
        }

        // create basketCheckoutEvent -- set TotalPrice on basketcheckout eventMessage
        var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);

        // send checkout event to rbbitmq
        // _eventBus.PublishBasketCheckout

        // remove the basket     
        await _basketRepository.DeleteBasket(basket.UserName);

        return Accepted();
    }
}
