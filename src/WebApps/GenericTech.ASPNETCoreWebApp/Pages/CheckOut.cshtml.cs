using GenericTech.ASPNETCoreWebApp.Models;
using GenericTech.ASPNETCoreWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericTech.ASPNETCoreWebApp.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public CheckOutModel(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = new ();

        public async Task<IActionResult> OnGetAsync()
        {
            var username = "swn";
            Cart = await _basketService.GetBasket(username);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var username = "swn";
            Cart = await _basketService.GetBasket(username);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = username;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketService.CheckoutBasket(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}