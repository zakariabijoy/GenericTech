using GenericTech.ASPNETCoreWebApp.Entities;

namespace GenericTech.ASPNETCoreWebApp.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> CheckOut(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}
