using MyShop.Web.API.Models.Products;

namespace MyShop.Web.API.Services.Foundation.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProductsAsync();
        ValueTask<Product> RetrieveProductByIdAsync(Guid productId);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductAsync(Product product);
    }
}
