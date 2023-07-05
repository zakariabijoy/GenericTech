using GenericTech.ASPNETCoreWebApp.Models;

namespace GenericTech.ASPNETCoreWebApp.Services.Interfaces;

public interface IBasketService
{
    Task<BasketModel> GetBasket(string userName);
    Task<BasketModel> UpdateBasket(BasketModel model);
    Task CheckoutBasket(BasketCheckoutModel model);
}
