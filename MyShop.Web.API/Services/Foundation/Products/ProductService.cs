using MyShop.Web.API.Broker.DateTimes;
using MyShop.Web.API.Broker.Loggings;
using MyShop.Web.API.Broker.Storages;
using MyShop.Web.API.Models.Products;
using System.Runtime.CompilerServices;

namespace MyShop.Web.API.Services.Foundation.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ProductService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"{product.Title} added.");

            product.Id= Guid.NewGuid();
            product.Created = this.dateTimeBroker.GetCurrentDateTime();
            product.CreatedBy = Guid.NewGuid();
            return await this.storageBroker.InsertProductAsync( product );
        }

        public async ValueTask<Product> ModifyProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"{product.Title} modified");
            return await this.storageBroker.UpdateProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"Product {product.Id} removed");
            return await this.storageBroker.DeleteProductAsync(product);
        }

        public IQueryable<Product> RetrieveAllProductsAsync()
        {
            return this.storageBroker.SelectAllProductsAsync();
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid productId)
        {
            return await this.storageBroker.SelectProductByIdAsync(productId);
        }
    }
}
