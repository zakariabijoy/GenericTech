﻿using GenericTech.ASPNETCoreWebApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericTech.ASPNETCoreWebApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public OrderModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public IEnumerable<Entities.Order> Orders { get; set; } = new List<Entities.Order>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderRepository.GetOrdersByUserName("test");

            return Page();
        }
    }
}