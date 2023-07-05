using GenericTech.ASPNETCoreWebApp.Models;

namespace GenericTech.ASPNETCoreWebApp.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
}
