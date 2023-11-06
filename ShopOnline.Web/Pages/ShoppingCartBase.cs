using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ShoppingCartBase:ComponentBase
    {
        [Inject]
        public IShoppingCartService shoppingCartService { get; set; }

        public List<CartItemDto> ShoppingCartItems { get; set; } //Menjamo iz IEnum u List 

        public string ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {

                ShoppingCartItems = await shoppingCartService.GetItems(HardCoded.UserId);


            }
            catch (Exception ex)
            {

                ErrorMessage=ex.Message;
            }
        }


        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto = await shoppingCartService.DeleteItem(id);
            RemoveCartItem(id);

        }

        private CartItemDto GetCartItem(int id) //dve privatne metode kako se ne bi vracali na api nego u clientu mozemo da obrisemo taj item. Bolji performans.
        {
            return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
        }


        private void RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);
            ShoppingCartItems.Remove(cartItemDto);

        }

    }
}
