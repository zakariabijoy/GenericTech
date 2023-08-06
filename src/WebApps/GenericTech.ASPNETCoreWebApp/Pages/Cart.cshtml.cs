using GenericTech.ASPNETCoreWebApp.Models;
using GenericTech.ASPNETCoreWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericTech.ASPNETCoreWebApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService )
        {
            _basketService = basketService;
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var username = "swn";
            Cart = await _basketService.GetBasket(username);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var username = "swn";
            var basket = await _basketService.GetBasket(username);

            var product = basket.Items.Single(i => i.ProductId == productId);
            basket.Items.Remove(product);

            await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}