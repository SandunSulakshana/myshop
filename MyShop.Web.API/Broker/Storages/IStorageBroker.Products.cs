using Microsoft.EntityFrameworkCore;
using MyShop.Web.API.Models.Products;

namespace MyShop.Web.API.Broker.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Product> InsertProductAsync(Product product);
        IQueryable<Product> SelectAllProductsAsync();  
        ValueTask<Product> SelectProductByIdAsync(Guid productId);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Product product);
    }
}
