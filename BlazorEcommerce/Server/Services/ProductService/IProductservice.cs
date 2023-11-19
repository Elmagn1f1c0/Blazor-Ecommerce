namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductservice
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
    }
}
