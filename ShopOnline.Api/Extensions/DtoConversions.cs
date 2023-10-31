using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto( IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            return(from product in products
                   join productCategory in productCategories
                   on product.CategoryId equals productCategory.Id
                   select new ProductDto
                   {
                       Id =product.Id,
                       Name=product.Name,
                       Description=product.Description,
                       Qty=product.Qty,
                       ImageURL=product.ImageURL,
                       Price=product.Price,
                       CategoryId=productCategory.Id,
                       CategoryName=productCategory.Name
                   }).ToList();
                
        }



    }
}
